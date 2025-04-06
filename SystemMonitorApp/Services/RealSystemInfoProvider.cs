using System;
using System.Diagnostics;
using SystemMonitorApp.Services.Contracts;
using Visiotech.HardwareInfo;
using System.Management;

namespace SystemMonitorApp.Services
{
    public class RealSystemInfoProvider : ISystemInfoProvider
    {
        private readonly PerformanceCounter _cpuCounter;
        private readonly PerformanceCounter _ramCounter;

        public RealSystemInfoProvider()
        {
            try
            {
                Console.WriteLine("[Init] Inicializando contadores de rendimiento...");
                _cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
                _ramCounter = new PerformanceCounter("Memory", "Available MBytes");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Al inicializar PerformanceCounters: {ex.Message}");
            }
        }

        public string GetCpuSerial()
        {
            Console.WriteLine("[LOG] Llamando a GetCpuSerial...");
            try
            {
                var result = HardwareInfo.GetProcessorID();
                Console.WriteLine($"[LOG] Resultado de GetCpuSerial: {result}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] GetCpuSerial: {ex.Message}");
                return "N/D";
            }
        }

        public string GetMotherboardSerial()
        {
            Console.WriteLine("[LOG] Llamando a GetMotherboardSerial...");
            try
            {
                var result = HardwareInfo.GetMotherboardID();
                Console.WriteLine($"[LOG] Resultado de GetMotherboardSerial: {result}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] GetMotherboardSerial: {ex.Message}");
                return "N/D";
            }
        }

        public string GetGpuSerial()
        {
            Console.WriteLine("[LOG] Llamando a GetGpuSerial (GPU Name real)");

            try
            {
                using var searcher = new ManagementObjectSearcher("SELECT Name FROM Win32_VideoController");

                foreach (var obj in searcher.Get())
                {
                    string name = obj["Name"]?.ToString() ?? "";

                    // Filtrar monitores virtuales u otros que no son GPU reales
                    if (!name.ToLower().Contains("microsoft") && !name.ToLower().Contains("basic") && !name.ToLower().Contains("virtual"))
                    {
                        Console.WriteLine($"[LOG] GPU detectada: {name}");
                        return name;
                    }
                }

                return "GPU no encontrada";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] GetGpuSerial: {ex.Message}");
                return "N/D";
            }
        }

        public string GetCpuUsage()
        {
            Console.WriteLine("[LOG] Llamando a GetCpuUsage...");
            try
            {
                _cpuCounter?.NextValue(); // lectura inicial
                System.Threading.Thread.Sleep(500); // esperar para dato real
                var value = _cpuCounter?.NextValue() ?? 0f;
                Console.WriteLine($"[LOG] Resultado de GetCpuUsage: {value:0.0}%");
                return $"{value:0.0}%";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] GetCpuUsage: {ex.Message}");
                return "N/D";
            }
        }

        public string GetRamUsage()
        {
            Console.WriteLine("[LOG] Llamando a GetRamUsage (WMI)");

            try
            {
                double totalMb = 0;
                using var searcher = new ManagementObjectSearcher("SELECT TotalVisibleMemorySize FROM Win32_OperatingSystem");

                foreach (var obj in searcher.Get())
                {
                    totalMb = Convert.ToDouble(obj["TotalVisibleMemorySize"]) / 1024; // en MB
                }

                float availableMb = _ramCounter?.NextValue() ?? 0f;
                float usedMb = (float)(totalMb - availableMb);
                Console.WriteLine($"[LOG] RAM Total: {totalMb:0.0} MB, Libre: {availableMb:0.0} MB, Usada: {usedMb:0.0} MB");

                return $"{usedMb:0.0} MB usadas de {totalMb:0.0} MB";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] GetRamUsage (WMI): {ex.Message}");
                return "N/D";
            }
        }
    }
}