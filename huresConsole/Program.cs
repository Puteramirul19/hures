using huresConsole.Scaffold.Context;
using huresConsole.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Internal;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

var services = new ServiceCollection();

services.AddDbContext<HuresContext>(options =>
    options.UseMySql(configuration.GetConnectionString("HuresConnection"),
        new MySqlServerVersion(new Version(5, 5, 62))

        ));

services.AddSingleton<IConfiguration>(configuration);

services.AddScoped<UnitWork>();
services.AddScoped<ReportingService>();

var serviceProvider = services.BuildServiceProvider();


char _exit = 'n';
var cancelSource = new CancellationTokenSource();
Console.CancelKeyPress += (sender, e) =>
{
    Console.WriteLine("\nBulk processing canceled by user.");
    cancelSource.Cancel();
    e.Cancel = true; // prevent immediate app termination
};

while (_exit != 'y')
{
    Console.WriteLine("\n--- Menu ---");
    Console.WriteLine("1. Process by ID");
    Console.WriteLine("2. Bulk process (press Ctrl+C to cancel)");
    Console.Write("Choose (1 or 2): ");
    var input = Console.ReadLine();
    using var scope = serviceProvider.CreateScope();
    var reportingService = scope.ServiceProvider.GetRequiredService<ReportingService>();
    var unitWork = scope.ServiceProvider.GetRequiredService<UnitWork>();

    switch (input)
    {
        case "1":
            Console.Write("Enter No Pekerja: ");
            var id = Console.ReadLine();

            Console.WriteLine($"start processing for maklumat asas");
            reportingService.maklumat_asas(id);
            Console.WriteLine($"end processing for maklumat asas");
            Console.WriteLine($"");
            Console.WriteLine($"start processing for gaji asas");
            reportingService.gaji_asas(id);
            Console.WriteLine($"end processing for maklumat asas");
            Console.WriteLine($"");
            Console.WriteLine($"start processing for ringkasan cuti");
            reportingService.head_ringkasan_cuti(id);
            Console.WriteLine($"end processing for ringkasan cuti");
            Console.WriteLine($"");
            Console.WriteLine($"start processing for senarai cuti");
            reportingService.head_senarai_cuti(id);
            Console.WriteLine($"end processing for senarai cuti");
            Console.WriteLine($"");

            Console.WriteLine($"Process Complete for Staff No : {id}");

            break;

        case "2":
            Console.WriteLine("Starting bulk processing... Press Ctrl+C to cancel.\n");

            try
            {
                var list = unitWork.getUnprocessedBatch();
                // get all unflagged staff
                foreach (var noPekerja in list)
                {
                    try
                    {
                        Console.WriteLine($"start processing for maklumat asas");
                        reportingService.maklumat_asas(noPekerja);
                        Console.WriteLine($"end processing for maklumat asas");
                        Console.WriteLine($"");
                        Console.WriteLine($"start processing for gaji asas");
                        reportingService.gaji_asas(noPekerja);
                        Console.WriteLine($"end processing for gaji asas");
                        Console.WriteLine($"");
                        Console.WriteLine($"start processing for ringkasan cuti");
                        reportingService.head_ringkasan_cuti(noPekerja);
                        Console.WriteLine($"end processing for ringkasan cuti");
                        Console.WriteLine($"");
                        Console.WriteLine($"start processing for senarai cuti");
                        reportingService.head_senarai_cuti(noPekerja);
                        Console.WriteLine($"end processing for senarai cuti");
                        Console.WriteLine($"");

                        Console.WriteLine($"Process Complete for Staff No : {noPekerja}");
                        var forNoReason = unitWork.updateProcessedDataAsas(noPekerja);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error processing {noPekerja}: {ex.Message}");
                        // Continue with next staff member
                    }
                }

                Console.WriteLine("Bulk processing completed!");
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Bulk processing interrupted.");
            }

            break;

        default:
            Console.Clear();
            Console.WriteLine("Invalid input. Please enter 1 or 2.");
            _exit = 'n';
            continue;
            break;
    }

    Console.Write("Do you want to exit? (Y/N): ");
    _exit = char.ToLower(Console.ReadKey().KeyChar);
    Console.WriteLine();
}


