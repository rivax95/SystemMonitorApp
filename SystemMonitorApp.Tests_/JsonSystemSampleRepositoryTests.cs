using NUnit.Framework;
using System.IO;
using System.Linq;
using SystemMonitorApp.Models;
using SystemMonitorApp.Repositories;

namespace SystemMonitorApp.Tests.Repositories
{
    public class JsonSystemSampleRepositoryTests
    {
        private JsonSystemSampleRepository _repo;
        private const string FilePath = "samples.json";

        [SetUp]
        public void Setup()
        {
            // Eliminar el archivo antes de cada test
            if (File.Exists(FilePath))
                File.Delete(FilePath);

            _repo = new JsonSystemSampleRepository();
            _repo.Initialize();
        }

        [Test]
        public void SaveSample_Should_WriteToFile()
        {
            var sample = new SystemSample
            {
                Timestamp = System.DateTime.Now,
                CpuSerial = "CPU-123",
                MotherboardSerial = "MB-456",
                GpuSerial = "GPU-789",
                CpuUsage = "20%",
                RamUsage = "1024 MB libres"
            };

            _repo.SaveSample(sample);

            Assert.That(File.Exists(FilePath), Is.True, "El archivo no se creó correctamente.");

        }

        [Test]
        public void LoadSamples_Should_ReturnSavedData()
        {
            var sample = new SystemSample
            {
                Timestamp = System.DateTime.Now,
                CpuSerial = "CPU-123",
                MotherboardSerial = "MB-456",
                GpuSerial = "GPU-789",
                CpuUsage = "20%",
                RamUsage = "1024 MB libres"
            };

            _repo.SaveSample(sample);

            var samples = _repo.LoadSamples().ToList();

            Assert.That(samples.Count, Is.EqualTo(1));
            Assert.That(samples[0].CpuSerial, Is.EqualTo("CPU-123"));
        }

        [Test]
        public void LoadSamples_Should_ReturnEmptyList_IfFileNotExists()
        {
            File.Delete(FilePath);

            var newRepo = new JsonSystemSampleRepository();
            newRepo.Initialize();

            var samples = newRepo.LoadSamples();

            Assert.That(samples, Is.Empty);
        }
    }
}
