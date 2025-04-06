using SystemMonitorApp.Services.Contracts;

namespace SystemMonitorApp.Services
{
    /// <summary>
    /// Implementación ficticia para pruebas, devuelve datos de ejemplo.
    /// </summary>
    public class PlaceholderSystemInfoProvider : ISystemInfoProvider
    {
        public string GetCpuSerial() => "CPU-SERIAL-PLACEHOLDER";
        public string GetMotherboardSerial() => "MB-SERIAL-PLACEHOLDER";
        public string GetGpuSerial() => "GPU-SERIAL-PLACEHOLDER";
        public string GetCpuUsage() => "25%";
        public string GetRamUsage() => "4096MB";
    }
}