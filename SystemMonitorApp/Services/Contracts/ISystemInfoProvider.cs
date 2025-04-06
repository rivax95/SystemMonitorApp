namespace SystemMonitorApp.Services.Contracts
{
    /// <summary>
    /// Interfaz para obtener información del hardware y uso del sistema.
    /// </summary>
    public interface ISystemInfoProvider
    {
        string GetCpuSerial();
        string GetMotherboardSerial();
        string GetGpuSerial();
        string GetCpuUsage();
        string GetRamUsage();
    }
}