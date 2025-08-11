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

while (_exit != 'y')
{
    // Create a new cancellation token for each operation
    var cancelSource = new CancellationTokenSource();
    Console.CancelKeyPress += (sender, e) =>
    {
        Console.WriteLine("\nBulk processing canceled by user.");
        cancelSource.Cancel();
        e.Cancel = true; // prevent immediate app termination
    };

    Console.WriteLine("\n--- Menu ---");
    Console.WriteLine("1. Process by ID");
    Console.WriteLine("2. Bulk process (press Ctrl+C to cancel)");
    Console.WriteLine("3. Bulk process selected IDs from CSV (press Ctrl+C to cancel)");
    Console.Write("Choose (1, 2, or 3): ");
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
            Console.WriteLine($"end processing for gaji asas");
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
                    // Check for cancellation before processing each staff member
                    cancelSource.Token.ThrowIfCancellationRequested();

                    try
                    {
                        Console.WriteLine($"start processing for maklumat asas");
                        reportingService.maklumat_asas(noPekerja);
                        Console.WriteLine($"end processing for maklumat asas");
                        Console.WriteLine($"");

                        // Check for cancellation between operations
                        cancelSource.Token.ThrowIfCancellationRequested();

                        Console.WriteLine($"start processing for gaji asas");
                        reportingService.gaji_asas(noPekerja);
                        Console.WriteLine($"end processing for gaji asas");
                        Console.WriteLine($"");

                        // Check for cancellation between operations
                        cancelSource.Token.ThrowIfCancellationRequested();

                        Console.WriteLine($"start processing for ringkasan cuti");
                        reportingService.head_ringkasan_cuti(noPekerja);
                        Console.WriteLine($"end processing for ringkasan cuti");
                        Console.WriteLine($"");

                        // Check for cancellation between operations
                        cancelSource.Token.ThrowIfCancellationRequested();

                        Console.WriteLine($"start processing for senarai cuti");
                        reportingService.head_senarai_cuti(noPekerja);
                        Console.WriteLine($"end processing for senarai cuti");
                        Console.WriteLine($"");

                        Console.WriteLine($"Process Complete for Staff No : {noPekerja}");
                        var forNoReason = unitWork.updateProcessedDataAsas(noPekerja);
                    }
                    catch (OperationCanceledException)
                    {
                        Console.WriteLine($"Processing cancelled while working on Staff No: {noPekerja}");
                        throw; // Re-throw to exit the main loop
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
                Console.WriteLine("Bulk processing was successfully cancelled by user.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during bulk processing: {ex.Message}");
            }
            break;

        case "3":
            Console.Write("Enter CSV file path (or press Enter for 'ids.csv'): ");
            var csvPath = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(csvPath))
            {
                csvPath = "ids.csv";
            }

            try
            {
                var selectedIds = ReadIdsFromCsv(csvPath);

                if (selectedIds.Count == 0)
                {
                    Console.WriteLine("No IDs found in CSV file.");
                    break;
                }

                Console.WriteLine($"Found {selectedIds.Count} IDs in CSV file.");
                Console.WriteLine("Starting bulk processing for selected IDs... Press Ctrl+C to cancel.\n");

                int processed = 0;
                foreach (var noPekerja in selectedIds)
                {
                    cancelSource.Token.ThrowIfCancellationRequested();

                    try
                    {
                        Console.WriteLine($"Processing {processed + 1}/{selectedIds.Count}: Staff No {noPekerja}");

                        Console.WriteLine($"start processing for maklumat asas");
                        reportingService.maklumat_asas(noPekerja);
                        Console.WriteLine($"end processing for maklumat asas");
                        Console.WriteLine($"");

                        cancelSource.Token.ThrowIfCancellationRequested();

                        Console.WriteLine($"start processing for gaji asas");
                        reportingService.gaji_asas(noPekerja);
                        Console.WriteLine($"end processing for gaji asas");
                        Console.WriteLine($"");

                        cancelSource.Token.ThrowIfCancellationRequested();

                        Console.WriteLine($"start processing for ringkasan cuti");
                        reportingService.head_ringkasan_cuti(noPekerja);
                        Console.WriteLine($"end processing for ringkasan cuti");
                        Console.WriteLine($"");

                        cancelSource.Token.ThrowIfCancellationRequested();

                        Console.WriteLine($"start processing for senarai cuti");
                        reportingService.head_senarai_cuti(noPekerja);
                        Console.WriteLine($"end processing for senarai cuti");
                        Console.WriteLine($"");

                        var forNoReason = unitWork.updateProcessedDataAsas(noPekerja);
                        processed++;
                        Console.WriteLine($"✓ Process Complete for Staff No: {noPekerja} ({processed}/{selectedIds.Count})\n");
                    }
                    catch (OperationCanceledException)
                    {
                        Console.WriteLine($"Processing cancelled while working on Staff No: {noPekerja}");
                        throw;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"✗ Error processing {noPekerja}: {ex.Message}");
                    }
                }

                Console.WriteLine($"Selected IDs bulk processing completed! Processed {processed}/{selectedIds.Count} successfully.");
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Selected IDs bulk processing was cancelled.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during bulk processing: {ex.Message}");
            }
            break;

        default:
            Console.Clear();
            Console.WriteLine("Invalid input. Please enter 1, 2, or 3.");
            _exit = 'n';
            continue;
    }

    Console.Write("Do you want to exit? (Y/N): ");
    _exit = char.ToLower(Console.ReadKey().KeyChar);
    Console.WriteLine();
}

static List<string> ReadIdsFromCsv(string filePath)
{
    var ids = new List<string>();
    try
    {
        var lines = File.ReadAllLines(filePath);
        foreach (var line in lines)
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                // If CSV has headers or other columns, split by comma and take first column
                var parts = line.Split(',');
                var id = parts[0].Trim().Trim('"'); // Remove quotes if any
                if (!string.IsNullOrWhiteSpace(id) && id != "NoPekerja") // Skip header
                {
                    ids.Add(id);
                }
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error reading CSV file: {ex.Message}");
    }
    return ids;
}