using System;
using System.Linq;
using SystemMonitorApp.Models;
using SystemMonitorApp.Repositories;
using SystemMonitorApp.Services;
using Xunit;

namespace SystemMonitorApp.Tests
{
    public class SystemSampleRepositoryTests
    {
        [Fact]
        public void Repository_Initializes_And_Creates_File_If_Not_Exists()
        {
            // Arrange
            var repo = new JsonSystemSampleRepository();
            repo.Initialize();

            // Act
            var samples = repo.LoadSamples();

            // Assert
            Assert.NotNull(samples);
        }

        [Fact]
        public void Repository_Can_Save_And_Load_Sample()
        {
            // Arrange
            var repo = new JsonSystemSampleRepository();
            repo.Initialize();
            var sample = new SystemSample
            {
                Timestamp = DateTime.Now,
                CpuSerial = "TESTCPU",
                MotherboardSerial = "TESTMB",
                GpuSerial = "TESTGPU",
                CpuUsage = "50%",
                RamUsage = "2048MB"
            };

            // Act
            repo.SaveSample(sample);
            var loadedSamples = repo.LoadSamples();

            // Assert
            Assert.Contains(loadedSamples, s => s.CpuSerial == "TESTCPU");
        }
    }

    public class PlaceholderSystemInfoProviderTests
    {
        [Fact]
        public void Placeholder_Returns_Expected_Values()
        {
            // Arrange
            var provider = new PlaceholderSystemInfoProvider();

            // Act & Assert
            Assert.Equal("CPU-SERIAL-PLACEHOLDER", provider.GetCpuSerial());
            Assert.Equal("MB-SERIAL-PLACEHOLDER", provider.GetMotherboardSerial());
            Assert.Equal("GPU-SERIAL-PLACEHOLDER", provider.GetGpuSerial());
            Assert.Equal("25%", provider.GetCpuUsage());
            Assert.Equal("4096MB", provider.GetRamUsage());
        }
    }
}