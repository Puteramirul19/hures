using huresConsole.Scaffold.Entity;
using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.Globalization;
using temp.scaffold.Model;

namespace huresConsole.Service
{
    public class ReportingService
    {
        private readonly UnitWork unitWork;

        public ReportingService(UnitWork _unitWork)
        {
            unitWork = _unitWork;
        }

        static void ReportFlush(string message)
        {
            //             string templatePath = Path.Combine("template", "report_template.html");
            //
            //             if (!File.Exists(templatePath))
            //             {
            //                 Console.WriteLine("Template file not found: " + templatePath);
            //                 return;
            //             }
            //
            //             string html = File.ReadAllText(templatePath);
            //
            //             // Replace placeholders with actual content
            //             html = html.Replace("{{Title}}", "Hello PDF")
            //                 .Replace("{{Body}}", message); // use message parameter here
            // #if DEBUG
            //             outputPath = Path.Combine("output", "");
            // #endif
            //             string dateFolder = DateTime.Now.ToString("yyyyMMdd");
            //             string outputDir = Path.Combine(outputPath, "report", dateFolder);
            //             Directory.CreateDirectory(outputDir);
            //
            //             string outputFilePath = Path.Combine(outputDir, "reportname.pdf");
            //
            //             using (FileStream pdfDest = new FileStream(outputFilePath, FileMode.Create))
            //             {
            //                 HtmlConverter.ConvertToPdf(html, pdfDest);
            //             }
            //
            //             Console.WriteLine("PDF created at: " + outputFilePath);
        }
        public void maklumat_asas(string staffNo)
        {
            DeviceRgb header = new DeviceRgb(0x46, 0x82, 0xB4);
            DeviceRgb cellHeader = new DeviceRgb(204, 240, 255);
            DeviceRgb cellValue = new DeviceRgb(246, 249, 255);
            PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.TIMES_BOLD);
            PdfFont defaultFont = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);
            string dest = $"{staffNo}_maklumat_asas.pdf";

            string path = unitWork.reportPath();
            string outputDir = Path.Combine(path, staffNo);
            Directory.CreateDirectory(outputDir);

            dest = Path.Combine(outputDir, dest);

            var data = unitWork.getDataAsasByNoPekerja(staffNo);
            if (data == null)
            {
                Console.WriteLine();
                Console.WriteLine($"No report found for {staffNo} to generate report Maklumat Asas");
                return;
            }

            using (PdfWriter writer = new PdfWriter(dest))
            using (PdfDocument pdf = new PdfDocument(writer))
            {
                Document document = new Document(pdf);
                document.SetMargins(10, 10, 10, 10);
                float[] columnWidths = { 25, 25, 25, 25 };
                Table table = new Table(UnitValue.CreatePercentArray(columnWidths)).UseAllAvailableWidth();

                // Header
                Cell mainHeader = new Cell(1, 4)
                    .Add(new Paragraph($"MAKLUMAT ASAS {data.NamaPekerja}").SetFontSize(7)
                        .SetFontColor(DeviceGray.WHITE)
                        .SetFont(boldFont))
                    .SetBackgroundColor(header)
                    .SetTextAlignment(TextAlignment.CENTER);
                table.AddCell(mainHeader);

                table.SetFont(defaultFont).SetFontSize(7);

                // Row 1: 
                table.AddCell(new Cell().Add(new Paragraph("NO PEKERJA")).SetBackgroundColor(cellHeader));
                table.AddCell(new Cell().Add(new Paragraph($"{data.NoPekerja}")).SetBackgroundColor(cellValue));
                table.AddCell(new Cell().Add(new Paragraph("NO K/PENGENALAN")).SetBackgroundColor(cellHeader));
                table.AddCell(new Cell().Add(new Paragraph($"{data.NoKadPengenalan}")).SetBackgroundColor(cellValue));

                // Row 2: 
                table.AddCell(new Cell().Add(new Paragraph("NAMA")).SetBackgroundColor(cellHeader));
                table.AddCell(new Cell().Add(new Paragraph($"{data.NamaPekerja}")).SetBackgroundColor(cellValue));
                table.AddCell(new Cell().Add(new Paragraph("OPSYEN")).SetBackgroundColor(cellHeader));
                table.AddCell(new Cell().Add(new Paragraph($"{data.Opsyen ?? "-"}")).SetBackgroundColor(cellValue));

                // Row 3: 
                table.AddCell(new Cell().Add(new Paragraph("NAMA LAIN")).SetBackgroundColor(cellHeader));
                table.AddCell(new Cell().Add(new Paragraph($"{data.NamaLain ?? "-"}")).SetBackgroundColor(cellValue));
                table.AddCell(new Cell().Add(new Paragraph("")).SetBackgroundColor(cellValue));
                table.AddCell(new Cell().Add(new Paragraph("")).SetBackgroundColor(cellValue));

                // Row 4: 
                table.AddCell(new Cell().Add(new Paragraph("TARIKH LAHIR")).SetBackgroundColor(cellHeader));
                var tarikhLahir = unitWork.formatDate_dd_mm_yyyy(data.TarikhLahir);
                if (tarikhLahir.Contains("Error"))
                {
                    unitWork.Log(data.NoPekerja, "TarikhLahir", $"Could not format date: {data.TarikhLahir}");
                    tarikhLahir = string.IsNullOrEmpty(data.TarikhLahir) ? "-" : data.TarikhLahir;
                }
                table.AddCell(new Cell().Add(new Paragraph($"{tarikhLahir}")).SetBackgroundColor(cellValue));
                table.AddCell(new Cell().Add(new Paragraph("JANTINA")).SetBackgroundColor(cellHeader));
                var jantina = data.Jantina == "P" ? "PEREMPUAN" : "LELAKI";
                table.AddCell(new Cell().Add(new Paragraph($"{jantina}")).SetBackgroundColor(cellValue));

                // Row 5: 
                table.AddCell(new Cell().Add(new Paragraph("BANGSA")).SetBackgroundColor(cellHeader));
                var keturunan = unitWork.getKeturunByKod(data.Keturunan);
                table.AddCell(new Cell().Add(new Paragraph($"{keturunan.KtrKeturunan}")).SetBackgroundColor(cellValue));
                table.AddCell(new Cell().Add(new Paragraph("TARAF KAHWIN")).SetBackgroundColor(cellHeader));
                var tarafKahwin = unitWork.getTarafKahwinByKod(data.TarafKahwin);
                table.AddCell(new Cell().Add(new Paragraph($"{tarafKahwin.KtrTarafKahwin}")).SetBackgroundColor(cellValue));

                // Row 6: 
                table.AddCell(new Cell().Add(new Paragraph("ALAMAT")).SetBackgroundColor(cellHeader));
                var alamatParts = new[] { data.AlamatBaris1, data.AlamatBaris2, data.AlamatBaris3, data.AlamatBaris4, data.AlamatBaris5 }
                    .Where(part => !string.IsNullOrWhiteSpace(part))
                    .Select(part => part.Trim().TrimEnd(',', '.'))
                    .Where(part => !string.IsNullOrEmpty(part))
                    .ToArray();
                var alamat = string.Join(", ", alamatParts)
                    .Replace(",", ", ")  // Replace single comma with comma + space
                    .Replace("  ", " ")  // Replace double spaces with single space
                    .Replace(", ,", ",") // Remove any leftover comma-space-comma patterns
                    .Trim();
                Cell alamatSpan = new Cell(1, 3).Add(new Paragraph($"{alamat}")).SetBackgroundColor(cellValue);
                table.AddCell(alamatSpan);

                // Row 7: 
                table.AddCell(new Cell().Add(new Paragraph("JBT/STN")).SetBackgroundColor(cellHeader));
                table.AddCell(new Cell().Add(new Paragraph($"{data.KodStesen}")).SetBackgroundColor(cellValue));
                table.AddCell(new Cell().Add(new Paragraph("TRH. MULA KHIDMAT")).SetBackgroundColor(cellHeader));
                var tarikhMulaKhidmat = unitWork.formatDate_dd_mm_yyyy(data.TarikhMulaKhidmat);
                if (tarikhMulaKhidmat.Contains("Error"))
                {
                    unitWork.Log(data.NoPekerja, "TarikhMulaKhidmat", $"Could not format date: {data.TarikhMulaKhidmat}");
                    tarikhMulaKhidmat = string.IsNullOrEmpty(data.TarikhMulaKhidmat) ? "-" : data.TarikhMulaKhidmat;
                }
                table.AddCell(new Cell().Add(new Paragraph($"{tarikhMulaKhidmat}")).SetBackgroundColor(cellValue));

                // Row 8: 
                table.AddCell(new Cell().Add(new Paragraph("")).SetBackgroundColor(cellValue));
                var stesen = unitWork.getStesenByKod(data.KodStesen);
                table.AddCell(new Cell().Add(new Paragraph($"{stesen?.Keterangan ?? ""}")).SetBackgroundColor(cellValue));
                table.AddCell(new Cell().Add(new Paragraph("TRH. SAH JAWATAN")).SetBackgroundColor(cellHeader));
                var tarikhSahJawatan = unitWork.formatDate_dd_mm_yyyy(data.TarikhSahJawatan);
                if (tarikhSahJawatan.Contains("Error"))
                {
                    unitWork.Log(data.NoPekerja, "TarikhSahJawatan", $"Could not format date: {data.TarikhSahJawatan}");
                    tarikhSahJawatan = string.IsNullOrEmpty(data.TarikhSahJawatan) ? "-" : data.TarikhSahJawatan;
                }
                table.AddCell(new Cell().Add(new Paragraph($"{tarikhSahJawatan}")).SetBackgroundColor(cellValue));

                // Row 9: 
                table.AddCell(new Cell().Add(new Paragraph("DAFTAR GAJI")).SetBackgroundColor(cellHeader));
                table.AddCell(new Cell().Add(new Paragraph($"{data.KodBahgDaftarGaji}")).SetBackgroundColor(cellValue));
                table.AddCell(new Cell().Add(new Paragraph("NO. RUJUKAN SAH JAWATAN")).SetBackgroundColor(cellHeader));
                table.AddCell(new Cell().Add(new Paragraph($"{data.NoRujukanKuasaSahJwt ?? "-"}")).SetBackgroundColor(cellValue));

                // Row 10: 
                table.AddCell(new Cell().Add(new Paragraph("")).SetBackgroundColor(cellValue));
                var kod = unitWork.getBDGajiByKod(data.KodBahgDaftarGaji);
                if (kod == null && !string.IsNullOrEmpty(data.KodBahgDaftarGaji))
                {
                    unitWork.Log(data.NoPekerja, "BDGaji", $"BDGaji not found for KodBahgDaftarGaji: {data.KodBahgDaftarGaji}");
                }
                table.AddCell(new Cell().Add(new Paragraph($"{kod?.KtrBDGaji ?? ""}")).SetBackgroundColor(cellValue));
                table.AddCell(new Cell().Add(new Paragraph("TRH. MASUK JABATAN")).SetBackgroundColor(cellHeader));
                var tarikhMasukJabatan = unitWork.formatDate_dd_mm_yyyy(data.TarikhMasukJabatan);
                if (tarikhMasukJabatan.Contains("Error"))
                {
                    unitWork.Log(data.NoPekerja, "TarikhMasukJabatan", $"Could not format date: {data.TarikhMasukJabatan}");
                    tarikhMasukJabatan = string.IsNullOrEmpty(data.TarikhMasukJabatan) ? "-" : data.TarikhMasukJabatan;
                }
                table.AddCell(new Cell().Add(new Paragraph($"{tarikhMasukJabatan}")).SetBackgroundColor(cellValue));

                string a = "";
                string b = "";
                JAWATAN jwt = null;

                if (!string.IsNullOrEmpty(data.KodKelasJawatan))
                {
                    try
                    {
                        if (data.KodKelasJawatan.Length >= 10)
                        {
                            a = data.KodKelasJawatan.Substring(data.KodKelasJawatan.Length - 10, 6);
                            b = data.KodKelasJawatan.Substring(data.KodKelasJawatan.Length - 4, 4);
                            jwt = unitWork.getTJawatan_TugasByKod(a, b);
                        }
                        else
                        {
                            unitWork.Log(data.NoPekerja, "KodKelasJawatan", $"KodKelasJawatan too short: {data.KodKelasJawatan}");
                        }
                    }
                    catch (Exception ex)
                    {
                        unitWork.Log(data.NoPekerja, "KodKelasJawatan", $"Error parsing KodKelasJawatan: {data.KodKelasJawatan}, Error: {ex.Message}");
                    }
                }

                if (jwt == null && !string.IsNullOrEmpty(data.KodKelasJawatan))
                {
                    unitWork.Log(data.NoPekerja, "Jawatan", $"Jawatan not found for codes a={a}, b={b}, KodKelasJawatan={data.KodKelasJawatan}");
                }

                // Row 11: 
                table.AddCell(new Cell().Add(new Paragraph("JAWATAN")).SetBackgroundColor(cellHeader));
                table.AddCell(new Cell().Add(new Paragraph($"{jwt?.Jawatan1 ?? ""}")).SetBackgroundColor(cellValue));
                table.AddCell(new Cell().Add(new Paragraph("KOD KELAS JAWATAN")).SetBackgroundColor(cellHeader));
                table.AddCell(new Cell().Add(new Paragraph($"{data.KodKelasJawatan}")).SetBackgroundColor(cellValue));

                // Row 12: 
                table.AddCell(new Cell().Add(new Paragraph("TUGAS")).SetBackgroundColor(cellHeader));
                table.AddCell(new Cell().Add(new Paragraph($"{jwt?.Tugas ?? ""}")).SetBackgroundColor(cellValue));
                table.AddCell(new Cell().Add(new Paragraph("KOD KELAS K/TANGAN")).SetBackgroundColor(cellHeader));
                table.AddCell(new Cell().Add(new Paragraph("")).SetBackgroundColor(cellValue));

                // Row 13: 
                table.AddCell(new Cell().Add(new Paragraph("MENYANDANG")).SetBackgroundColor(cellHeader));
                var menyandang = unitWork.getMenyandangByKod(data.TarafMenyandang);
                if (menyandang == null && !string.IsNullOrEmpty(data.TarafMenyandang))
                {
                    unitWork.Log(data.NoPekerja, "Menyandang", $"Menyandang not found for TarafMenyandang: {data.TarafMenyandang}");
                }
                table.AddCell(new Cell().Add(new Paragraph($"{menyandang?.KtrMenyandang ?? ""}")).SetBackgroundColor(cellValue));
                table.AddCell(new Cell().Add(new Paragraph("TRH. NAIK PANGKAT")).SetBackgroundColor(cellHeader));
                var tarikhTukarNaikPangkat = unitWork.formatDate_dd_mm_yyyy(data.TarikhTukarNaikPangkat);
                if (tarikhTukarNaikPangkat.Contains("Error"))
                {
                    unitWork.Log(data.NoPekerja, "TarikhTukarNaikPangkat", $"Could not format date: {data.TarikhTukarNaikPangkat}");
                    tarikhTukarNaikPangkat = string.IsNullOrEmpty(data.TarikhTukarNaikPangkat) ? "-" : data.TarikhTukarNaikPangkat;
                }
                table.AddCell(new Cell().Add(new Paragraph($"{tarikhTukarNaikPangkat}")).SetBackgroundColor(cellValue));

                // Row 14: 
                table.AddCell(new Cell().Add(new Paragraph("")).SetBackgroundColor(cellValue));
                table.AddCell(new Cell().Add(new Paragraph("")).SetBackgroundColor(cellValue));
                table.AddCell(new Cell().Add(new Paragraph("NO. RUJUKAN")).SetBackgroundColor(cellHeader));
                table.AddCell(new Cell().Add(new Paragraph($"{data.NoRujukanKuasa ?? "-"}")).SetBackgroundColor(cellValue));

                // Row 15: 
                table.AddCell(new Cell().Add(new Paragraph("KOD GAJI")).SetBackgroundColor(cellHeader));
                table.AddCell(new Cell().Add(new Paragraph($"{data.KodGaji}")).SetBackgroundColor(cellValue));
                table.AddCell(new Cell().Add(new Paragraph("TRH. BERKUASA")).SetBackgroundColor(cellHeader));
                var tarikhGajiMula = unitWork.formatDate_dd_mm_yyyy(data.TarikhGajiMula);
                if (tarikhGajiMula.Contains("Error"))
                {
                    unitWork.Log(data.NoPekerja, "TarikhGajiMula", $"Could not format date: {data.TarikhGajiMula}");
                    tarikhGajiMula = string.IsNullOrEmpty(data.TarikhGajiMula) ? "-" : data.TarikhGajiMula;
                }
                table.AddCell(new Cell().Add(new Paragraph($"{tarikhGajiMula}")).SetBackgroundColor(cellValue));

                // Row 16: 
                table.AddCell(new Cell().Add(new Paragraph("GAJI POKOK")).SetBackgroundColor(cellHeader));
                var gajiPokokFormatted = unitWork.gajiPokok(data.GajiPokok);
                if (string.IsNullOrEmpty(gajiPokokFormatted) || gajiPokokFormatted == data.GajiPokok)
                {
                    unitWork.Log(data.NoPekerja, "GajiPokok", $"Could not format GajiPokok value: '{data.GajiPokok}'");
                }
                table.AddCell(new Cell().Add(new Paragraph($"{gajiPokokFormatted}")).SetBackgroundColor(cellValue));
                table.AddCell(new Cell().Add(new Paragraph("TRH. KENAIKAN GAJI")).SetBackgroundColor(cellHeader));
                var tarikhGajiNaik = unitWork.getTarikhGajiNaik(data.NoPekerja, data.TarikhGajiMula, data.KodGaji);
                if (!string.IsNullOrEmpty(tarikhGajiNaik))
                {
                    var formattedTarikhGajiNaik = unitWork.formatDate_dd_mm_yyyy(tarikhGajiNaik);
                    if (formattedTarikhGajiNaik.Contains("Error"))
                    {
                        unitWork.Log(data.NoPekerja, "TarikhGajiNaik", $"Could not format date: {tarikhGajiNaik}");
                        table.AddCell(new Cell().Add(new Paragraph($"{tarikhGajiNaik}")).SetBackgroundColor(cellValue));
                    }
                    else
                    {
                        table.AddCell(new Cell().Add(new Paragraph($"{formattedTarikhGajiNaik}")).SetBackgroundColor(cellValue));
                    }
                }
                else
                {
                    unitWork.Log(data.NoPekerja, "TarikhGajiNaik", $"TarikhGajiNaik not found for NoPekerja: {data.NoPekerja}, TarikhGajiMula: {data.TarikhGajiMula}, KodGaji: {data.KodGaji}");
                    table.AddCell(new Cell().Add(new Paragraph("-")).SetBackgroundColor(cellValue));
                }

                // Row 17: 
                table.AddCell(new Cell().Add(new Paragraph("SKIL GAJI")).SetBackgroundColor(cellHeader));
                var skilGaji = unitWork.getSkilGajiByKod(data.KodGaji);
                if (skilGaji == null && !string.IsNullOrEmpty(data.KodGaji))
                {
                    unitWork.Log(data.NoPekerja, "SkilGaji", $"SkilGaji not found for KodGaji: {data.KodGaji}");
                }
                table.AddCell(new Cell().Add(new Paragraph($"{skilGaji?.KtrSkilGaji ?? ""}")).SetBackgroundColor(cellValue));
                table.AddCell(new Cell().Add(new Paragraph("")).SetBackgroundColor(cellValue));
                table.AddCell(new Cell().Add(new Paragraph("")).SetBackgroundColor(cellValue));

                // Row 18: 
                table.AddCell(new Cell().Add(new Paragraph("NO. CUKAI PENDAPATAN")).SetBackgroundColor(cellHeader));
                table.AddCell(new Cell().Add(new Paragraph($"{data.NoCukaiPendapatan}")).SetBackgroundColor(cellValue));
                table.AddCell(new Cell().Add(new Paragraph("NO. KWSP")).SetBackgroundColor(cellHeader));
                table.AddCell(new Cell().Add(new Paragraph($"{data.NoEpf}")).SetBackgroundColor(cellValue));

                // Row 19: 
                table.AddCell(new Cell().Add(new Paragraph("KOD REKOD SEPI")).SetBackgroundColor(cellHeader));
                var rekodSepi = unitWork.getRekodSepiByKod(data.KodRekodSepi);
                string rekodSepiText = rekodSepi != null ? $"{rekodSepi.KtrRekodSepi} ({data.KodRekodSepi})" : "";
                table.AddCell(new Cell().Add(new Paragraph($"{rekodSepiText}")).SetBackgroundColor(cellValue));
                table.AddCell(new Cell().Add(new Paragraph("TRH. MULA SEPI")).SetBackgroundColor(cellHeader));
                var TarikhSepi = unitWork.formatDate_dd_mm_yyyy(data.TarikhSepi);
                if (TarikhSepi.Contains("Error"))
                {
                    unitWork.Log(data.NoPekerja, "TarikhSepi", $"Could not format date: {data.TarikhSepi}");
                    TarikhSepi = string.IsNullOrEmpty(data.TarikhSepi) ? "-" : data.TarikhSepi;
                }
                table.AddCell(new Cell().Add(new Paragraph($"{TarikhSepi}")).SetBackgroundColor(cellValue));

                // Row 20: 
                table.AddCell(new Cell().Add(new Paragraph("OPSYEN 'CASH INDICATOR'")).SetBackgroundColor(cellHeader));
                string cashIndicator = string.IsNullOrEmpty(data.OpsyenCashIndicator) ? "-" : data.OpsyenCashIndicator;
                table.AddCell(new Cell().Add(new Paragraph($"{cashIndicator}")).SetBackgroundColor(cellValue));
                table.AddCell(new Cell().Add(new Paragraph("TAHUN OPSYEN")).SetBackgroundColor(cellHeader));
                string tahunOpsyen = string.IsNullOrEmpty(data.TahunOpsyen) || data.TahunOpsyen == "0000" ? "-" : data.TahunOpsyen;
                table.AddCell(new Cell().Add(new Paragraph($"{tahunOpsyen}")).SetBackgroundColor(cellValue));

                // Add table to document
                document.Add(table);
            }

            Console.WriteLine("PDF created: " + Path.GetFullPath(dest));
        }

        public void gaji_asas(string staffNo)
        {
            DeviceRgb header = new DeviceRgb(0x46, 0x82, 0xB4);
            DeviceRgb cellHeader = new DeviceRgb(204, 240, 255);
            DeviceRgb cellValue = new DeviceRgb(246, 249, 255);
            PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.TIMES_BOLD);
            PdfFont defaultFont = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);
            string dest = $"{staffNo}_gaji_asas.pdf";

            string path = unitWork.reportPath();
            string outputDir = Path.Combine(path, staffNo);
            Directory.CreateDirectory(outputDir);

            dest = Path.Combine(outputDir, dest);


            var asas = unitWork.getDataAsasByNoPekerja(staffNo);
            var data = unitWork.getGajiListByNoPekerja(staffNo);


            using (PdfWriter writer = new PdfWriter(dest))
            using (PdfDocument pdf = new PdfDocument(writer))
            using (Document document = new Document(pdf))
            {
                document.SetMargins(10, 10, 10, 10);
                float[] columnWidths1 = { 25, 25, 25, 25 }; // Customize per row requirement
                Table table1 = new Table(UnitValue.CreatePercentArray(columnWidths1)).UseAllAvailableWidth();

                // Header
                Cell mainHeader = new Cell(1, 4)
                    .Add(new Paragraph($"GAJI ASAS {asas.NamaPekerja}").SetFontSize(6).SetFontColor(DeviceGray.WHITE)
                        .SetFont(boldFont))
                    .SetBackgroundColor(header)
                    .SetTextAlignment(TextAlignment.CENTER);
                table1.AddCell(mainHeader);

                table1.SetFont(defaultFont).SetFontSize(6);

                // Row 1
                table1.AddCell(new Cell().Add(new Paragraph("NO PEKERJA")).SetBackgroundColor(cellHeader));
                table1.AddCell(new Cell().Add(new Paragraph($"{asas.NoPekerja}")).SetBackgroundColor(cellValue));
                table1.AddCell(new Cell().Add(new Paragraph("NAMA")).SetBackgroundColor(cellHeader));
                table1.AddCell(new Cell().Add(new Paragraph($"{asas.NamaPekerja}")).SetBackgroundColor(cellValue));

                // Row 2
                table1.AddCell(new Cell().Add(new Paragraph("STESEN")).SetBackgroundColor(cellHeader));
                table1.AddCell(new Cell().Add(new Paragraph($"{asas.KodStesen}")).SetBackgroundColor(cellValue));
                table1.AddCell(new Cell().Add(new Paragraph("TARIKH MULA KHIDMAT")).SetBackgroundColor(cellHeader));
                table1.AddCell(new Cell().Add(new Paragraph($"{unitWork.formatDate_dd_mm_yyyy(asas.TarikhMulaKhidmat)}")).SetBackgroundColor(cellValue));

                document.Add(table1);

                float[] columnWidths2 =
                {
                    2, // index
                    8, // tarikh mula gaji
                    6, // kod gaji
                    20, // skil gaji
                    8, // gaji pokok
                    14, // kod perubahan gaji
                    10, // kod ulang kaji
                    8, // tarikh gaji naik
                    8, // jumlah perubahan gaji
                    8, // jumlah elaun prestasi
                    8 // no rujukan
                }; // Customize per row requirement
                Table table2 = new Table(UnitValue.CreatePercentArray(columnWidths2)).UseAllAvailableWidth();

                table2.SetFont(defaultFont).SetFontSize(6);

                table2.AddCell(new Cell().Add(new Paragraph("")).SetBackgroundColor(header)
                    .SetFontColor(DeviceGray.WHITE).SetFont(boldFont));
                table2.AddCell(new Cell().Add(new Paragraph($"TARIKH MULA GAJI")).SetBackgroundColor(header)
                    .SetFontColor(DeviceGray.WHITE).SetFont(boldFont));
                table2.AddCell(new Cell().Add(new Paragraph("KOD GAJI")).SetBackgroundColor(header)
                    .SetFontColor(DeviceGray.WHITE).SetFont(boldFont));
                table2.AddCell(new Cell().Add(new Paragraph($"SKIL GAJI")).SetBackgroundColor(header)
                    .SetFontColor(DeviceGray.WHITE).SetFont(boldFont));
                table2.AddCell(new Cell().Add(new Paragraph("GAJI POKOK")).SetBackgroundColor(header)
                    .SetFontColor(DeviceGray.WHITE).SetFont(boldFont));
                table2.AddCell(new Cell().Add(new Paragraph($"KOD PERUBAHAN GAJI")).SetBackgroundColor(header)
                    .SetFontColor(DeviceGray.WHITE).SetFont(boldFont));
                table2.AddCell(new Cell().Add(new Paragraph("KOD ULANG KAJI")).SetBackgroundColor(header)
                    .SetFontColor(DeviceGray.WHITE).SetFont(boldFont));
                table2.AddCell(new Cell().Add(new Paragraph($"TARIKH GAJI NAIK")).SetBackgroundColor(header)
                    .SetFontColor(DeviceGray.WHITE).SetFont(boldFont));
                table2.AddCell(new Cell().Add(new Paragraph("JUMLAH PERUBAHAN GAJI")).SetBackgroundColor(header)
                    .SetFontColor(DeviceGray.WHITE).SetFont(boldFont));
                table2.AddCell(new Cell().Add(new Paragraph("JUMLAH ELAUN PRESTASI")).SetBackgroundColor(header)
                    .SetFontColor(DeviceGray.WHITE).SetFont(boldFont));
                table2.AddCell(new Cell().Add(new Paragraph($"NO RUJUKAN")).SetBackgroundColor(header)
                    .SetFontColor(DeviceGray.WHITE).SetFont(boldFont));

                int row = 1;
                foreach (var i in data)
                {
                    table2.AddCell(new Cell().Add(new Paragraph($"{row}")).SetBackgroundColor(cellValue));
                    table2.AddCell(new Cell().Add(new Paragraph($"{unitWork.formatDate_dd_mm_yyyy(i.TarikhGajiMula)}"))
                        .SetBackgroundColor(cellValue)); // tarikh mula gaji
                    table2.AddCell(new Cell().Add(new Paragraph($"{i.KodGaji}"))
                        .SetBackgroundColor(cellValue)); // kod gaji
                    var skilgaji = unitWork.getSkilGajiByKod(i.KodGaji);
                    table2.AddCell(new Cell().Add(new Paragraph($"{skilgaji?.KtrSkilGaji ?? ""}"))
                        .SetBackgroundColor(cellValue)); // skill gaji
                    table2.AddCell(new Cell().Add(new Paragraph($"{unitWork.gajiPokok(i.GajiPokok)}"))
                        .SetBackgroundColor(cellValue)); // gaji pokok
                    var perubahanGaji = unitWork.getPerubahanGajiByKod(i.KodPerubahanGaji);
                    table2.AddCell(new Cell()
                        .Add(new Paragraph($"{perubahanGaji?.KtrPerubahanGaji} ({i.KodPerubahanGaji})"))
                        .SetBackgroundColor(cellValue)); // kod perubahan gaji
                    table2.AddCell(new Cell().Add(new Paragraph($" {i.KodUlangkaji}"))
                        .SetBackgroundColor(cellValue)); // kod ulangkaji gaji
                    var temp = i.TarikhGajiNaik == "0000" ? "" : i.TarikhGajiNaik.Insert(2, "-");
                    table2.AddCell(new Cell().Add(new Paragraph($"{temp}"))
                        .SetBackgroundColor(cellValue)); // tarikh gaji naik
                    table2.AddCell(new Cell().Add(new Paragraph($"{unitWork.gajiPokok(i.JumlahPerubahanGaji)}"))
                        .SetBackgroundColor(cellValue)); // jumlah perubahan gaji
                    table2.AddCell(new Cell().Add(new Paragraph($"{unitWork.gajiPokok(i.JumlahPrestasi)}"))
                        .SetBackgroundColor(cellValue)); // jumlah elaun prestasi
                    string noRujukan = string.IsNullOrEmpty(i.NoRujukanPerubahanGaji) || 
                                       i.NoRujukanPerubahanGaji.Trim() == "" || 
                                       i.NoRujukanPerubahanGaji == "000000" ? "-" : i.NoRujukanPerubahanGaji.Trim();
                    table2.AddCell(new Cell().Add(new Paragraph($"{noRujukan}"))
                        .SetBackgroundColor(cellValue)); // no rujukan
                    row++;
                }

                document.Add(table2);
            }

            Console.WriteLine("PDF created: " + Path.GetFullPath(dest));
        }
        public void head_ringkasan_cuti(string staffNo)
        {
            var asas = unitWork.getDataAsasByNoPekerja(staffNo);
            var data = unitWork.getGajiListByNoPekerja(staffNo);

            var leave = unitWork.getRingkasanCutiByNoPekerja(staffNo);
            foreach (var i in leave)
            {
                ringkasan_cuti(asas, i);
            }
        }
        public void ringkasan_cuti(DATAASAS asas, LEAVE leave)
        {
            DeviceRgb header = new DeviceRgb(0x46, 0x82, 0xB4);
            DeviceRgb cellHeader = new DeviceRgb(204, 240, 255);
            DeviceRgb cellValue = new DeviceRgb(246, 249, 255);
            PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.TIMES_BOLD);
            PdfFont defaultFont = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);
            string dest = $"{asas.NoPekerja}_ringkasan_cuti_{leave.TahunCuti}";
            if (leave.PetunjukCuti != "")
                dest = dest + $"_{leave.PetunjukCuti}";
            dest = dest + ".pdf";

            string path = unitWork.reportPath();
            string outputDir = Path.Combine(path, asas.NoPekerja, "ringkasan_cuti");
            Directory.CreateDirectory(outputDir);

            dest = Path.Combine(outputDir, dest);


            DateTime? tempDate = null;
            string formatTempDate = "";

            using (PdfWriter writer = new PdfWriter(dest))
            using (PdfDocument pdf = new PdfDocument(writer))
            {
                Document document = new Document(pdf);
                document.SetMargins(10, 10, 10, 10);
                float[] columnWidths = { 25, 25, 25, 25 }; // Customize per row requirement
                Table table = new Table(UnitValue.CreatePercentArray(columnWidths)).UseAllAvailableWidth();

                // Header
                Cell mainHeader = new Cell(1, 4)
                    .Add(new Paragraph($"RINGKASAN CUTI {asas.NamaPekerja}").SetFontSize(7).SetFontColor(DeviceGray.WHITE)
                        .SetFont(boldFont))
                    .SetBackgroundColor(header)
                    .SetTextAlignment(TextAlignment.CENTER);
                table.AddCell(mainHeader);

                table.SetFont(defaultFont).SetFontSize(7);

                // Row 1
                table.AddCell(new Cell().Add(new Paragraph("NO PEKERJA")).SetBackgroundColor(cellHeader));
                table.AddCell(new Cell().Add(new Paragraph($"{asas.NoPekerja}")).SetBackgroundColor(cellValue));
                table.AddCell(new Cell().Add(new Paragraph("NAMA")).SetBackgroundColor(cellHeader));
                table.AddCell(new Cell().Add(new Paragraph($"{asas.NamaPekerja}")).SetBackgroundColor(cellValue));

                // Row 2
                table.AddCell(new Cell().Add(new Paragraph("KOD STESEN")).SetBackgroundColor(cellHeader));
                table.AddCell(new Cell().Add(new Paragraph($"{asas.KodStesen}")).SetBackgroundColor(cellValue));
                table.AddCell(new Cell().Add(new Paragraph("GRED GAJI")).SetBackgroundColor(cellHeader));
                table.AddCell(new Cell().Add(new Paragraph($"{asas.KodGaji}")).SetBackgroundColor(cellValue));

                // Row 3
                table.AddCell(new Cell().Add(new Paragraph("PERUBAHAN LAYAK")).SetBackgroundColor(cellHeader));
                string perubahanLayak = string.IsNullOrEmpty(leave.PerubahanLayak) ? "-" : leave.PerubahanLayak;
                table.AddCell(new Cell().Add(new Paragraph($"{perubahanLayak}")).SetBackgroundColor(cellValue));
                table.AddCell(new Cell().Add(new Paragraph("TAHUN CUTI")).SetBackgroundColor(cellHeader));
                table.AddCell(new Cell().Add(new Paragraph($"{leave.TahunCuti}")).SetBackgroundColor(cellValue));

                // Row 4
                table.AddCell(new Cell().Add(new Paragraph("TARIKH KUATKUASA")).SetBackgroundColor(cellHeader));

                if (leave.TarikhKuatkuasa != "00000000")
                {
                    DateTime tempDateParsed;
                    // Try multiple date formats safely
                    if (DateTime.TryParseExact(leave.TarikhKuatkuasa, "ddMMyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out tempDateParsed))
                    {
                        formatTempDate = tempDateParsed.ToString("dd-MM-yyyy");
                    }
                    else if (DateTime.TryParseExact(leave.TarikhKuatkuasa, "MMddyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out tempDateParsed))
                    {
                        formatTempDate = tempDateParsed.ToString("dd-MM-yyyy");
                    }
                    else if (DateTime.TryParseExact(leave.TarikhKuatkuasa, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out tempDateParsed))
                    {
                        formatTempDate = tempDateParsed.ToString("dd-MM-yyyy");
                    }
                    else
                    {
                        formatTempDate = "Invalid Date";
                    }
                }
                else
                {
                    formatTempDate = "";
                }

                // Display "-" if empty, otherwise show the formatted date
                string displayTarikhKuatkuasa = string.IsNullOrEmpty(formatTempDate) ? "-" : formatTempDate;
                table.AddCell(new Cell().Add(new Paragraph($"{displayTarikhKuatkuasa}")).SetBackgroundColor(cellValue));
                table.AddCell(new Cell().Add(new Paragraph("")).SetBackgroundColor(cellHeader));
                table.AddCell(new Cell().Add(new Paragraph($"")).SetBackgroundColor(cellValue));

                // Row 5
                table.AddCell(new Cell().Add(new Paragraph("KELAYAKAN CUTI")).SetBackgroundColor(cellHeader));
                table.AddCell(new Cell().Add(new Paragraph($"{unitWork.kelayakanCuti(leave.KelayakanCuti)}")).SetBackgroundColor(cellValue));
                table.AddCell(new Cell().Add(new Paragraph("OPSYEN TUKAR WANG TUNAI")).SetBackgroundColor(cellHeader));
                table.AddCell(new Cell().Add(new Paragraph($"{unitWork.opsTukarWangTunaiTahunan(leave.OpsTukarWangTunaiThn)}")).SetBackgroundColor(cellValue));

                // Row 6
                table.AddCell(new Cell().Add(new Paragraph("CUTI LAMA DIBAWA")).SetBackgroundColor(cellHeader));
                var kodCuti = unitWork.getKodCutibyKtr(leave.CutiLamaDibawa[^1].ToString());
                if (kodCuti == null)
                {
                    unitWork.Log(asas.NoPekerja, "kodCuti", $"Object reference not set to an instance of an object. kodCuti was null for KtrLeave: {leave.CutiLamaDibawa[^1].ToString()}");
                    table.AddCell(new Cell().Add(new Paragraph($"{unitWork.cutiLamaDibawa(leave.CutiLamaDibawa, "")}")).SetBackgroundColor(cellValue));
                }
                else
                {
                    table.AddCell(new Cell().Add(new Paragraph($"{unitWork.cutiLamaDibawa(leave.CutiLamaDibawa, kodCuti.KodLeave)}")).SetBackgroundColor(cellValue));
                }
                table.AddCell(new Cell().Add(new Paragraph("TAHUN OPSYEN")).SetBackgroundColor(cellHeader));
                // Handle "0000" case in addition to null/empty
                string tahunOpsyen = string.IsNullOrEmpty(asas.TahunOpsyen) || asas.TahunOpsyen == "0000" ? "-" : asas.TahunOpsyen;
                table.AddCell(new Cell().Add(new Paragraph($"{tahunOpsyen}")).SetBackgroundColor(cellValue));

                // Row 7
                table.AddCell(new Cell().Add(new Paragraph("JUMLAH CUTI BAGI TAHUN")).SetBackgroundColor(cellHeader));
                table.AddCell(new Cell().Add(new Paragraph($"{unitWork.generalCutiFormat(leave.JumlahCutiBagiTahun)}")).SetBackgroundColor(cellValue));
                table.AddCell(new Cell().Add(new Paragraph("CUTI SAKIT")).SetBackgroundColor(cellHeader));
                table.AddCell(new Cell().Add(new Paragraph($"{unitWork.generalCutiFormat(leave.CutiSakit)}")).SetBackgroundColor(cellValue));

                // Row 8
                table.AddCell(new Cell().Add(new Paragraph("CUTI DIAMBIL")).SetBackgroundColor(cellHeader));
                table.AddCell(new Cell().Add(new Paragraph($"{unitWork.generalCutiFormat(leave.CutiDiambil)}")).SetBackgroundColor(cellValue));
                table.AddCell(new Cell().Add(new Paragraph("CUTI TANPA GAJI")).SetBackgroundColor(cellHeader));
                table.AddCell(new Cell().Add(new Paragraph($"{unitWork.generalCutiFormat(leave.CutiTanpaGaji)}")).SetBackgroundColor(cellValue));

                // Row 9
                table.AddCell(new Cell().Add(new Paragraph("CUTI DIBAWA KEDEPAN")).SetBackgroundColor(cellHeader));
                table.AddCell(new Cell().Add(new Paragraph($"{unitWork.generalCutiFormat(leave.CutiDibawaKeDepan)}")).SetBackgroundColor(cellValue));
                table.AddCell(new Cell().Add(new Paragraph("TIDAK HADIR")).SetBackgroundColor(cellHeader));
                table.AddCell(new Cell().Add(new Paragraph($"{unitWork.generalCutiFormat(leave.TidakHadir)}")).SetBackgroundColor(cellValue));

                // Row 10
                table.AddCell(new Cell().Add(new Paragraph("CUTI DIHAPUSKAN")).SetBackgroundColor(cellHeader));
                table.AddCell(new Cell().Add(new Paragraph($"{unitWork.generalCutiFormat(leave.CutiDihapuskan)}")).SetBackgroundColor(cellValue));
                table.AddCell(new Cell().Add(new Paragraph("CUTI SEPARUH GAJI")).SetBackgroundColor(cellHeader));
                table.AddCell(new Cell().Add(new Paragraph($"{unitWork.generalCutiFormat(leave.CutiSeparuhGaji)}")).SetBackgroundColor(cellValue));

                // Row 11
                table.AddCell(new Cell().Add(new Paragraph("CUTI REHAT TAHUN KUMPUL")).SetBackgroundColor(cellHeader));
                table.AddCell(new Cell().Add(new Paragraph($"{unitWork.generalCutiFormat(leave.CutiRehatTahunKumpul)}")).SetBackgroundColor(cellValue));
                table.AddCell(new Cell().Add(new Paragraph("TAHUN MULA CUTI DIKUMPUL")).SetBackgroundColor(cellHeader));
                string tahunMulaCuti = unitWork.generalCutiFormat(leave.TahunMulaCutiDikumpul);
                if (tahunMulaCuti == "0.0") tahunMulaCuti = "-";
                table.AddCell(new Cell().Add(new Paragraph($"{tahunMulaCuti}")).SetBackgroundColor(cellValue));

                // Row 12
                table.AddCell(new Cell().Add(new Paragraph("CUTI REHAT TAHUN KUMPUL LAMA"))
                    .SetBackgroundColor(cellHeader));
                table.AddCell(new Cell().Add(new Paragraph($"{unitWork.generalCutiFormat(leave.JumlahCutiRehatTahunKumpul)}")).SetBackgroundColor(cellValue));
                table.AddCell(new Cell().Add(new Paragraph("CUTI SEBERANG LAUT KUMPUL"))
                    .SetBackgroundColor(cellHeader));
                table.AddCell(new Cell().Add(new Paragraph($"{unitWork.generalCutiFormat(leave.CutiSeberangLaut)}")).SetBackgroundColor(cellValue));

                // Row 13
                table.AddCell(new Cell().Add(new Paragraph("CUTI REHAT TAHUN KUMPUL DIGUNA"))
                    .SetBackgroundColor(cellHeader));
                table.AddCell(new Cell().Add(new Paragraph($"{unitWork.generalCutiFormat(leave.CutiRehatTahunKumpulDiguna)}")).SetBackgroundColor(cellValue));
                table.AddCell(new Cell().Add(new Paragraph("CUTI TANPA GAJI TAHUN DIKUMPUL"))
                    .SetBackgroundColor(cellHeader));
                table.AddCell(new Cell().Add(new Paragraph($"{unitWork.generalCutiFormat(leave.CutiTanpaGajiDikumpul)}")).SetBackgroundColor(cellValue));

                // Row 14
                table.AddCell(new Cell().Add(new Paragraph("CUTI SEBERANG LAUT LAMA")).SetBackgroundColor(cellHeader));
                table.AddCell(new Cell().Add(new Paragraph($"{unitWork.generalCutiFormat(leave.CutiSeberangLautLama)}")).SetBackgroundColor(cellValue));
                table.AddCell(new Cell().Add(new Paragraph("CUTI DIBEKUKAN")).SetBackgroundColor(cellHeader));
                table.AddCell(new Cell().Add(new Paragraph($"{unitWork.generalCutiFormat(leave.CutiDibekukan)}")).SetBackgroundColor(cellValue));

                // Row 15
                table.AddCell(new Cell().Add(new Paragraph("CUTI SEBERANG LAUT DIAMBIL")).SetBackgroundColor(cellHeader));
                table.AddCell(new Cell().Add(new Paragraph($"{unitWork.generalCutiFormat(leave.CutiSeberangLautDiambil)}")).SetBackgroundColor(cellValue));
                table.AddCell(new Cell().Add(new Paragraph("CUTI TUKAR KE WANG TUNAI KUMPUL"))
                    .SetBackgroundColor(cellHeader));
                string cutiTukarWangTunaiKumpul = unitWork.generalCutiFormat(leave.CutiTukarWangTunaiDikumpul);
                if (cutiTukarWangTunaiKumpul == "0.0") cutiTukarWangTunaiKumpul = "0.00";
                table.AddCell(new Cell().Add(new Paragraph($"{cutiTukarWangTunaiKumpul}")).SetBackgroundColor(cellValue));

                // Row 16
                table.AddCell(new Cell().Add(new Paragraph("CUTI TUKAR KE WANG TUNAI")).SetBackgroundColor(cellHeader));
                table.AddCell(new Cell().Add(new Paragraph($"{unitWork.generalCutiFormat(leave.CutiTukarKeWangTunai)}")).SetBackgroundColor(cellValue));
                table.AddCell(new Cell().Add(new Paragraph("NO RUJUKAN CUTI SAKIT")).SetBackgroundColor(cellHeader));
                string noRujukanCutiSakit = string.IsNullOrEmpty(leave.NoRujukanCutiSakit90) ? "-" : leave.NoRujukanCutiSakit90;
                table.AddCell(new Cell().Add(new Paragraph($"{noRujukanCutiSakit}")).SetBackgroundColor(cellValue));
                // Add table to document
                document.Add(table);
            }

            Console.WriteLine("PDF created: " + Path.GetFullPath(dest));
        }
        public void head_senarai_cuti(string staffNo)
        {
            var asas = unitWork.getDataAsasByNoPekerja(staffNo);
            var data = unitWork.getGajiListByNoPekerja(staffNo);

            for (int i = 83; i <= 99; i++)
            {
                var leave = unitWork.getLeaveListByNoPekerja(staffNo, i.ToString());
                if (leave.Count() <= 0)
                    continue;
                senarai_cuti(asas, i.ToString(), leave);
            }
        }
        public void senarai_cuti(DATAASAS asas, string year, List<LeaveListDto> leaveListDto)
        {
            DeviceRgb header = new DeviceRgb(0x46, 0x82, 0xB4);
            DeviceRgb cellHeader = new DeviceRgb(204, 240, 255);
            DeviceRgb cellValue = new DeviceRgb(246, 249, 255);
            PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.TIMES_BOLD);
            PdfFont defaultFont = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);
            string dest = $"{asas.NoPekerja}_senarai_cuti_19{year}.pdf";

            string path = unitWork.reportPath();
            string outputDir = Path.Combine(path, asas.NoPekerja, "senarai_cuti");
            Directory.CreateDirectory(outputDir);

            dest = Path.Combine(outputDir, dest);

            using (PdfWriter writer = new PdfWriter(dest))
            using (PdfDocument pdf = new PdfDocument(writer))
            {
                Document document = new Document(pdf);
                document.SetMargins(10, 10, 10, 10);
                float[] columnWidths1 = { 25, 25, 25, 25 }; // Customize per row requirement
                Table table1 = new Table(UnitValue.CreatePercentArray(columnWidths1)).UseAllAvailableWidth();

                // Header
                Cell mainHeader = new Cell(1, 4)
                    .Add(new Paragraph($"SENARAI CUTI {asas.NamaPekerja} (19{year})").SetFontSize(6).SetFontColor(DeviceGray.WHITE)
                        .SetFont(boldFont))
                    .SetBackgroundColor(header)
                    .SetTextAlignment(TextAlignment.CENTER);
                table1.AddCell(mainHeader);

                table1.SetFont(defaultFont).SetFontSize(6);

                // Row 1
                table1.AddCell(new Cell().Add(new Paragraph("NO PEKERJA")).SetBackgroundColor(cellHeader));
                table1.AddCell(new Cell().Add(new Paragraph($"{asas.NoPekerja}")).SetBackgroundColor(cellValue));
                table1.AddCell(new Cell().Add(new Paragraph("NAMA")).SetBackgroundColor(cellHeader));
                table1.AddCell(new Cell().Add(new Paragraph($"{asas.NamaPekerja}")).SetBackgroundColor(cellValue));

                // Row 2
                table1.AddCell(new Cell().Add(new Paragraph("STESEN")).SetBackgroundColor(cellHeader));
                table1.AddCell(new Cell().Add(new Paragraph($"{asas.KodStesen}")).SetBackgroundColor(cellValue));
                table1.AddCell(new Cell().Add(new Paragraph("NO KAD PENGENALAN")).SetBackgroundColor(cellHeader));
                table1.AddCell(new Cell().Add(new Paragraph($"{asas.NoKadPengenalan}")).SetBackgroundColor(cellValue));

                // Row 3
                table1.AddCell(new Cell().Add(new Paragraph("TAHUN CUTI")).SetBackgroundColor(cellHeader));
                table1.AddCell(new Cell().Add(new Paragraph($"19{year}")).SetBackgroundColor(cellValue));
                table1.AddCell(new Cell().Add(new Paragraph("")).SetBackgroundColor(cellHeader));
                table1.AddCell(new Cell().Add(new Paragraph($"")).SetBackgroundColor(cellValue));

                document.Add(table1);

                float[] columnWidths2 =
                {
                    7, // index
                    12, // tarikh mula cuti
                    12, // tarik tamat cuti
                    22, // jenis cuti
                    12, // hari am
                    12, // hari cuti
                    7, // no rujukan cuti
                }; // Customize per row requirement
                Table table2 = new Table(UnitValue.CreatePercentArray(columnWidths2)).UseAllAvailableWidth();

                table2.SetFont(defaultFont).SetFontSize(6);

                table2.AddCell(new Cell().Add(new Paragraph("NO")).SetBackgroundColor(header)
                    .SetFontColor(DeviceGray.WHITE).SetFont(boldFont));
                table2.AddCell(new Cell().Add(new Paragraph($"TARIKH MULA CUTI")).SetBackgroundColor(header)
                    .SetFontColor(DeviceGray.WHITE).SetFont(boldFont));
                table2.AddCell(new Cell().Add(new Paragraph("TARIKH TAMAT CUTI")).SetBackgroundColor(header)
                    .SetFontColor(DeviceGray.WHITE).SetFont(boldFont));
                table2.AddCell(new Cell().Add(new Paragraph($"JENIS CUTI")).SetBackgroundColor(header)
                    .SetFontColor(DeviceGray.WHITE).SetFont(boldFont));
                table2.AddCell(new Cell().Add(new Paragraph("HARI AM")).SetBackgroundColor(header)
                    .SetFontColor(DeviceGray.WHITE).SetFont(boldFont));
                table2.AddCell(new Cell().Add(new Paragraph($"HARI CUTI")).SetBackgroundColor(header)
                    .SetFontColor(DeviceGray.WHITE).SetFont(boldFont));
                table2.AddCell(new Cell().Add(new Paragraph("NO RUJUKAN CUTI")).SetBackgroundColor(header)
                    .SetFontColor(DeviceGray.WHITE).SetFont(boldFont));


                var row = 1;
                foreach (var x in leaveListDto)
                {
                    table2.AddCell(new Cell().Add(new Paragraph($"{row}")).SetBackgroundColor(cellValue));
                    table2.AddCell(new Cell().Add(new Paragraph($"{unitWork.formatDate_dd_mm_yyyy(x.TarikhCutiMula)}")).SetBackgroundColor(cellValue));
                    table2.AddCell(new Cell().Add(new Paragraph($"{unitWork.formatDate_dd_mm_yyyy(x.TarikhCutiTamat)}")).SetBackgroundColor(cellValue));
                    var cuti = unitWork.getCutibyKod(x.JenisCuti);

                    // Format JENIS CUTI with code appended
                    string jenisCutiText = $"{cuti.KtrCuti}({x.JenisCuti})";
                    table2.AddCell(new Cell().Add(new Paragraph($"{jenisCutiText}")).SetBackgroundColor(cellValue));

                    // Format HARI AM - show "-" for empty/null/00/spaces, otherwise show the value
                    string hariAm = string.IsNullOrEmpty(x.BilHariAmRehat) ||
                                    x.BilHariAmRehat.Trim() == "" ||
                                    x.BilHariAmRehat.Trim() == "00" ||
                                    x.BilHariAmRehat.Trim() == "0" ? "-" : x.BilHariAmRehat.Trim();
                    table2.AddCell(new Cell().Add(new Paragraph($"{hariAm}")).SetBackgroundColor(cellValue));

                    table2.AddCell(new Cell().Add(new Paragraph($"{unitWork.generalCutiFormat(x.BilHariCuti)}")).SetBackgroundColor(cellValue));

                    // Format NO RUJUKAN CUTI - show "-" if empty/null, otherwise show the value
                    string noRujukan = string.IsNullOrEmpty(x.NoRujukanCuti) || x.NoRujukanCuti.Trim() == "" ? "-" : x.NoRujukanCuti.Trim();
                    table2.AddCell(new Cell().Add(new Paragraph($"{noRujukan}")).SetBackgroundColor(cellValue));

                    row++;
                }

                document.Add(table2);
            }

            Console.WriteLine("PDF created: " + Path.GetFullPath(dest));
        }
    }
}