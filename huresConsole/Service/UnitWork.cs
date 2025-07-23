using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;
using huresConsole.Scaffold.Context;
using huresConsole.Scaffold.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using temp.scaffold.Model;

namespace huresConsole.Service
{
    public class UnitWork
    {
        HuresContext context;
        private static string outputPath;
        private static string logPath;

        public UnitWork(HuresContext context, IConfiguration configuration)
        {
            this.context = context;
            outputPath = configuration["OutputFolder"];
            logPath = configuration["logFolder"];
            if (!OperatingSystem.IsWindows()) 
            {
                outputPath = Path.Combine(AppContext.BaseDirectory, "");
                logPath = Path.Combine(AppContext.BaseDirectory, logPath);
            }

            Directory.CreateDirectory(logPath);
        }

        #region CORE

        public string reportPath()
        {
            if (string.IsNullOrWhiteSpace(outputPath))
            {
                outputPath = Path.Combine(AppContext.BaseDirectory, "output");
                Console.WriteLine("OutputFolder not configured. Defaulting to 'bin/output'.");
            }

            string dateFolder = DateTime.Now.ToString("yyyyMMdd");
            string outputDir = Path.Combine(outputPath, "report");
            Directory.CreateDirectory(outputDir);

            return outputDir;
        }

        public string gajiPokok(string gajiPokok)
        {
            if (string.IsNullOrWhiteSpace(gajiPokok) || (gajiPokok.Length != 6 && gajiPokok.Length != 7))
                return gajiPokok; // return original if not 6 or 7 digits

            if (gajiPokok.All(c => c == '0'))
                return "0.00";

            string result = "";

            if (gajiPokok.Length == 7)
            {
                if (gajiPokok[0] == '0' && gajiPokok[1] != '0')
                {
                    result += gajiPokok.Substring(1, 4) + ".";
                }
                else if (gajiPokok[0] != '0')
                {
                    result += gajiPokok.Substring(0, 5) + ".";
                }
                else if (gajiPokok[0] == '0' && gajiPokok[1] == '0' && gajiPokok[2] != '0')
                {
                    result += gajiPokok.Substring(2, 3) + ".";
                }

                result += gajiPokok.Substring(5, 2); // Always append last 2 digits
            }
            else if (gajiPokok.Length == 6)
            {
                if (gajiPokok[0] == '0' && gajiPokok[1] != '0')
                {
                    result += gajiPokok.Substring(1, 3) + ".";
                }
                else if (gajiPokok[0] != '0')
                {
                    result += gajiPokok.Substring(0, 4) + ".";
                }
                else if (gajiPokok[0] == '0' && gajiPokok[1] == '0' && gajiPokok[2] != '0')
                {
                    result += gajiPokok.Substring(2, 2) + ".";
                }

                result += gajiPokok.Substring(4, 2); // Last 2 digits for 6-digit value
            }

            return result;
        }

        public string kelayakanCuti(string KelayakanCuti)
        {
            if (string.IsNullOrEmpty(KelayakanCuti))
                return "-";

            int length = KelayakanCuti.Length;
            string result = "";

            if (length >= 5 && KelayakanCuti[length - 5] != '0')
            {
                result += KelayakanCuti.Substring(length - 5, 4) + ".";
            }
            else if (length >= 4 && KelayakanCuti[length - 5] == '0' && KelayakanCuti[length - 4] != '0')
            {
                result += KelayakanCuti.Substring(length - 4, 3) + ".";
            }
            else if (length >= 3 && KelayakanCuti[length - 5] == '0' && KelayakanCuti[length - 4] == '0' &&
                     KelayakanCuti[length - 3] != '0')
            {
                result += KelayakanCuti.Substring(length - 3, 2) + ".";
            }
            else if (length >= 2 && KelayakanCuti[length - 5] == '0' && KelayakanCuti[length - 4] == '0' &&
                     KelayakanCuti[length - 3] == '0' && KelayakanCuti[length - 2] != '0')
            {
                result += KelayakanCuti.Substring(length - 2, 1) + ".";
            }
            else if (length >= 2 && KelayakanCuti[length - 5] == '0' && KelayakanCuti[length - 4] == '0' &&
                     KelayakanCuti[length - 3] == '0' && KelayakanCuti[length - 2] == '0')
            {
                result += KelayakanCuti.Substring(length - 2, 1) + ".";
            }

            if (length >= 1)
                result += KelayakanCuti[length - 1];

            return result;
        }

        public string opsTukarWangTunaiTahunan(string OpsTukarWangTunaiThn)
        {
            if (string.IsNullOrEmpty(OpsTukarWangTunaiThn))
                return "-";

            int length = OpsTukarWangTunaiThn.Length;
            string result = "";

            if (length >= 5 && OpsTukarWangTunaiThn[length - 5] != '0')
            {
                result += OpsTukarWangTunaiThn.Substring(length - 5, 4) + ".";
            }
            else if (length >= 4 && OpsTukarWangTunaiThn[length - 5] == '0' && OpsTukarWangTunaiThn[length - 4] != '0')
            {
                result += OpsTukarWangTunaiThn.Substring(length - 4, 3) + ".";
            }
            else if (length >= 3 && OpsTukarWangTunaiThn[length - 5] == '0' &&
                     OpsTukarWangTunaiThn[length - 4] == '0' && OpsTukarWangTunaiThn[length - 3] != '0')
            {
                result += OpsTukarWangTunaiThn.Substring(length - 3, 2) + ".";
            }
            else if (length >= 2 && OpsTukarWangTunaiThn[length - 5] == '0' &&
                     OpsTukarWangTunaiThn[length - 4] == '0' &&
                     OpsTukarWangTunaiThn[length - 3] == '0' && OpsTukarWangTunaiThn[length - 2] != '0')
            {
                result += OpsTukarWangTunaiThn.Substring(length - 2, 1) + ".";
            }
            else if (length >= 2 && OpsTukarWangTunaiThn[length - 5] == '0' &&
                     OpsTukarWangTunaiThn[length - 4] == '0' &&
                     OpsTukarWangTunaiThn[length - 3] == '0' && OpsTukarWangTunaiThn[length - 2] == '0')
            {
                result += OpsTukarWangTunaiThn.Substring(length - 2, 1) + ".";
            }

            if (length >= 1)
                result += OpsTukarWangTunaiThn[length - 1];

            return result;
        }

        public string cutiLamaDibawa(string CutiLamaDibawa, string KtrLeave)
        {
            if (string.IsNullOrEmpty(CutiLamaDibawa))
                return "-";

            int lengthCLD = CutiLamaDibawa.Length;
            int lengthKL = KtrLeave?.Length ?? 0;

            string result = "";

            if (lengthKL >= 2 && KtrLeave[lengthKL - 2] == '-')
                result += KtrLeave[lengthKL - 2];

            if (lengthCLD >= 5 && CutiLamaDibawa[lengthCLD - 5] != '0')
                result += CutiLamaDibawa.Substring(lengthCLD - 5, 4) + ".";
            else if (lengthCLD >= 4 && CutiLamaDibawa[lengthCLD - 5] == '0' && CutiLamaDibawa[lengthCLD - 4] != '0')
                result += CutiLamaDibawa.Substring(lengthCLD - 4, 3) + ".";
            else if (lengthCLD >= 3 && CutiLamaDibawa[lengthCLD - 5] == '0' && CutiLamaDibawa[lengthCLD - 4] == '0' &&
                     CutiLamaDibawa[lengthCLD - 3] != '0')
                result += CutiLamaDibawa.Substring(lengthCLD - 3, 2) + ".";
            else if (lengthCLD >= 2 && CutiLamaDibawa[lengthCLD - 5] == '0' && CutiLamaDibawa[lengthCLD - 4] == '0' &&
                     CutiLamaDibawa[lengthCLD - 3] == '0' && CutiLamaDibawa[lengthCLD - 2] != '0')
                result += CutiLamaDibawa.Substring(lengthCLD - 2, 1) + ".";
            else if (lengthCLD >= 2 && CutiLamaDibawa[lengthCLD - 5] == '0' && CutiLamaDibawa[lengthCLD - 4] == '0' &&
                     CutiLamaDibawa[lengthCLD - 3] == '0' && CutiLamaDibawa[lengthCLD - 2] == '0')
                result += CutiLamaDibawa.Substring(lengthCLD - 2, 1) + ".";

            if (lengthCLD >= 1 && (CutiLamaDibawa[lengthCLD - 1] == '0' || CutiLamaDibawa[lengthCLD - 1] == '5'))
                result += CutiLamaDibawa[lengthCLD - 1];
            else if (lengthKL >= 1)
                result += KtrLeave[lengthKL - 1];

            return result;
        }

        public string generalCutiFormat(string general5digit)
        {
            if (string.IsNullOrEmpty(general5digit))
                return "-";

            // Ensure it's 5 digits by padding on the left
            general5digit = general5digit.PadLeft(5, '0');

            char[] arr = general5digit.ToCharArray();
            string result = "";

            if (arr[0] != '0')
                result += new string(arr, 0, 4) + ".";
            else if (arr[1] != '0')
                result += new string(arr, 1, 3) + ".";
            else if (arr[2] != '0')
                result += new string(arr, 2, 2) + ".";
            else if (arr[3] != '0')
                result += arr[3] + ".";
            else
                result += arr[3] + "."; // even if 0000X, still append 4th + "."

            result += arr[4]; // always append last digit

            return result;
        }

        public string formatDate_dd_mm_yyyy(string date)
        {
            try
            {
                string[] errRange = ["000000", "00000000"];
                if (errRange.Contains(date))
                {
                    return "-";
                }

                var tempDate = string.IsNullOrEmpty(date)
                    ? (DateTime?)null
                    : DateTime.ParseExact(date, "ddMMyyyy", null);
                var formatTempDate = tempDate.HasValue ? tempDate.Value.ToString("dd-MM-yyyy") : "";
                return formatTempDate;
            }
            catch (Exception e)
            {
                return $"Error parsing date: {e.Message}";
            }
        }

        public string formatDate_ddMMMyyyy(string date)
        {
            try
            {
                CultureInfo ms_MY = new CultureInfo("ms-MY");

                if (DateTime.TryParseExact(date, "ddMMyyyy", ms_MY, DateTimeStyles.None, out DateTime dateTime))
                {
                    return dateTime.ToString("dd MMMM yyyy", ms_MY);
                }

                if (DateTime.TryParse(date, ms_MY, DateTimeStyles.None, out dateTime))
                {
                    return dateTime.ToString("dd MMMM yyyy", ms_MY);
                }

                return date;
            }
            catch (Exception e)
            {
                return $"Error parsing date: {e.Message}";
            }
        }


        public DATAASAS getDataAsasByNoPekerja(string noPekerja)
        {
            return context.DATAASAS.Where(w => w.NoPekerja == noPekerja).FirstOrDefault();
        }

        public List<GAJI> getGajiListByNoPekerja(string noPekerja)
        {
            return context.GAJI.Where(w => w.NoPekerja == noPekerja)
                .ToList() // Get data first
                .OrderBy(o => {
                    try
                    {
                        return DateTime.ParseExact(o.TarikhGajiMula, "ddMMyyyy", null);
                    }
                    catch
                    {
                        return DateTime.MinValue; // Put invalid dates at the beginning
                    }
                })
                .ToList();
        }

        public List<LEAVE> getRingkasanCutiByNoPekerja(string noPekerja)
        {
            return context.LEAVE.Where(w => w.NoPekerja == noPekerja).OrderByDescending(o => o.TahunCuti).ToList();
        }

        public List<LeaveListDto> getLeaveListByNoPekerja(string noPekerja, string year)
        {
            string entityName = $"LEAVELIST{year}";

            // Get the assembly from a known entity type (change LEAVELIST83 if needed)
            var entityAssembly = typeof(LEAVELIST83).Assembly;

            var entityType = entityAssembly.GetTypes()
                .FirstOrDefault(t => t.Name.Equals(entityName, StringComparison.OrdinalIgnoreCase));

            // 2. Get DbSet<T> property from DbContext for this entity type
            var dbSetProperty = context.GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .FirstOrDefault(p => p.PropertyType.IsGenericType
                                     && p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>)
                                     && p.PropertyType.GenericTypeArguments[0] == entityType);

            if (dbSetProperty == null)
                throw new Exception($"DbSet<{entityName}> not found in DbContext.");

            // 3. Get IQueryable from DbSet property
            var dbSet = (IQueryable)dbSetProperty.GetValue(context);

            // 4. Build expression: x => x.NoPekerja == noPekerja
            var parameter = Expression.Parameter(entityType, "x");
            var property = Expression.Property(parameter, "NoPekerja");
            var constant = Expression.Constant(noPekerja);
            var equals = Expression.Equal(property, constant);
            var lambda = Expression.Lambda(equals, parameter);

            // 5. Call Where<T>(source, lambda)
            var whereMethod = typeof(Queryable).GetMethods()
                .First(m => m.Name == "Where"
                            && m.GetParameters().Length == 2)
                .MakeGenericMethod(entityType);

            var filteredQuery = (IQueryable)whereMethod.Invoke(null, new object[] { dbSet, lambda });

            // 6. Execute query ToList<T>()
            var toListMethod = typeof(Enumerable).GetMethod("ToList")
                .MakeGenericMethod(entityType);

            var entityList = toListMethod.Invoke(null, new object[] { filteredQuery });

            // 7. Map each entity to LeaveListDto
            var results = new List<LeaveListDto>();

            foreach (var entity in (IEnumerable<object>)entityList)
            {
                var dto = new LeaveListDto
                {
                    NoPekerja = GetProp(entity, "NoPekerja"),
                    NamaPekerja = GetProp(entity, "NamaPekerja"),
                    KodStesen = GetProp(entity, "KodStesen"),
                    NoKadPengenalan = GetProp(entity, "NoKadPengenalan"),
                    KodRekodSepi = GetProp(entity, "KodRekodSepi"),
                    KodGaji = GetProp(entity, "KodGaji"),
                    TahunCuti = GetProp(entity, "TahunCuti"),
                    PetunjukCuti = GetProp(entity, "PetunjukCuti"),
                    TarikhCutiMula = GetProp(entity, "TarikhCutiMula"),
                    TarikhCutiTamat = GetProp(entity, "TarikhCutiTamat"),
                    JenisCuti = GetProp(entity, "JenisCuti"),
                    BilHariAmRehat = GetProp(entity, "BilHariAmRehat"),
                    BilHariCuti = GetProp(entity, "BilHariCuti"),
                    NoRujukanCuti = GetProp(entity, "NoRujukanCuti")
                };
                results.Add(dto);
            }

            return results;
        }

        private string GetProp(object obj, string propName)
        {
            var prop = obj.GetType().GetProperty(propName);
            if (prop == null) return null;
            var value = prop.GetValue(obj);
            return value?.ToString();
        }

        public List<String> getUnprocessedBatch()
        {
            return context.DATAASAS.Where(w => (bool)!w.isProcessed).Select(s => s.NoPekerja).ToList();
        }

        public bool updateProcessedDataAsas(string noPekerja)
        {
            var x = context.DATAASAS.Where(w => w.NoPekerja == noPekerja).FirstOrDefault();
            x.isProcessed = true;
            context.SaveChanges();
            return true;
        }

        #endregion

        #region LOOKUP

        public KETURUNAN getKeturunByKod(string kod)
        {
            return context.KETURUNAN.Where(w => w.KodKeturunan == kod).FirstOrDefault();
        }

        public TARAFKAHWIN getTarafKahwinByKod(string kod)
        {
            return context.TARAFKAHWIN.Where(w => w.KodTarafKahwin == kod).FirstOrDefault();
        }

        public BDGAJI getBDGajiByKod(string kod)
        {
            return context.BDGAJI.Where(w => w.KodBhgDaftarGaji == kod).FirstOrDefault();
        }

        public REKODSEPI getRekodSepiByKod(string kod)
        {
            return context.REKODSEPI.Where(w => w.KodRekodSepi == kod).FirstOrDefault();
        }

        public SKILGAJI getSkilGajiByKod(string kod)
        {
            return context.SKILGAJI.Where(w => w.KodSkilGaji == kod).FirstOrDefault();
        }

        public JAWATAN getTJawatan_TugasByKod(string kod, string tugas)
        {
            return context.JAWATAN.Where(w => w.KodJawatan == kod && w.KodTugas == tugas).FirstOrDefault();
        }

        public MENYANDANG getMenyandangByKod(string kod)
        {
            return context.MENYANDANG.Where(w => w.KodMenyandang == kod).FirstOrDefault();
        }

        public PERUBAHANGAJI getPerubahanGajiByKod(string kod)
        {
            return context.PERUBAHANGAJI.Where(w => w.KodPerubahanGaji == kod).FirstOrDefault();
        }

        public string getTarikhGajiNaik(string noPekerja, string tarikhGajiMula, string KodGaji)
        {
            var k = context.GAJI.Where(w => w.NoPekerja == noPekerja && tarikhGajiMula == KodGaji).FirstOrDefault();
            if (k == null)
            {
                return "";
            }

            return k.TarikhGajiMula;
        }

        public KODCUTI getKodCutibyKtr(string ktr)
        {
            if (ktr == "}")
                ktr = "-0";
            return context.KODCUTI.Where(w => w.KtrLeave == ktr).FirstOrDefault();
        }

        public CUTI getCutibyKod(string kod)
        {
            return context.CUTI.Where(w => w.KodCuti == kod).FirstOrDefault();
        }

        public STESEN getStesenByKod(string kod)
        {
            return context.STESEN.Where(w => w.KodStesen == kod).FirstOrDefault();
        }

        #endregion

        #region logging

        public void Log(string noPekerja, string column, string message)
        {
            string datePart = DateTime.Now.ToString("yyyyMMdd");
            string fileName = $"hures_console_log_{datePart}.txt";
            string filePath = Path.Combine(logPath, fileName);

            string logLine =
                $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] No Pekerja : {noPekerja}\nColumn name {column} = {message}\n";

            File.AppendAllText(filePath, logLine + Environment.NewLine);
        }

        #endregion
    }
}