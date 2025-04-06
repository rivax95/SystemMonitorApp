using System.Collections.Generic;
using SystemMonitorApp.Models;

namespace SystemMonitorApp.Repositories.Contracts
{
    /// <summary>
    /// Interfaz para acceder y persistir muestras del sistema.
    /// </summary>
    public interface ISystemSampleRepository
    {
        /// <summary>
        /// Inicializa el sistema de almacenamiento si no existe.
        /// </summary>
        void Initialize();

        /// <summary>
        /// Guarda una muestra del sistema.
        /// </summary>
        void SaveSample(SystemSample sample);

        /// <summary>
        /// Carga todas las muestras almacenadas.
        /// </summary>
        IEnumerable<SystemSample> LoadSamples();
    }
}