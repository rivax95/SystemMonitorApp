namespace SystemMonitorApp.Models
{
    /// <summary>
    /// Representa una muestra del estado del sistema en un momento dado.
    /// </summary>
    public class SystemSample
    {
        public DateTime Timestamp { get; set; }
        public string CpuSerial { get; set; }
        public string MotherboardSerial { get; set; }
        public string GpuSerial { get; set; }
        public string CpuUsage { get; set; }
        public string RamUsage { get; set; }
    }
}