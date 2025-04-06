using System.IO;
using System.Text.Json;
using SystemMonitorApp.Models;
using SystemMonitorApp.Repositories.Contracts;

namespace SystemMonitorApp.Repositories
{
    /// <summary>
    /// Implementación de repositorio que almacena datos en un archivo JSON.
    /// </summary>
    public class JsonSystemSampleRepository : ISystemSampleRepository
    {
        private const string FilePath = "samples.json";

        /// <inheritdoc/>
        public void Initialize()
        {
            if (!File.Exists(FilePath))
            {
                var emptyList = new List<SystemSample>();
                var json = JsonSerializer.Serialize(emptyList, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(FilePath, json);
            }
        }

        /// <inheritdoc/>
        public void SaveSample(SystemSample sample)
        {
            var samples = new List<SystemSample>(LoadSamples()) { sample };
            var json = JsonSerializer.Serialize(samples, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }

        /// <inheritdoc/>
        public IEnumerable<SystemSample> LoadSamples()
        {
            if (!File.Exists(FilePath)) return new List<SystemSample>();
            var json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<SystemSample>>(json) ?? new List<SystemSample>();
        }
    }
}