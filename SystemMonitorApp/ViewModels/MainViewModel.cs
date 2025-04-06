using System.Collections.ObjectModel;
using SystemMonitorApp.Models;
using SystemMonitorApp.Repositories.Contracts;
using SystemMonitorApp.Services.Contracts;
using SystemMonitorApp.Core.MVVM;
using Timer = System.Timers.Timer;

namespace SystemMonitorApp.ViewModels
{
    /// <summary>
    /// ViewModel principal que gestiona la lógica de muestreo del sistema.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly ISystemSampleRepository _repository;
        private readonly ISystemInfoProvider _infoProvider;
        private Timer _timer;
        private bool _isRunning;
        private int _interval;

        public ObservableCollection<SystemSample> Samples { get; set; }

        public bool IsRunning
        {
            get => _isRunning;
            set { _isRunning = value; OnPropertyChanged(); }
        }

        public int Interval
        {
            get => _interval;
            set { _interval = value; OnPropertyChanged(); UpdateTimer(); }
        }

        public MainViewModel(ISystemSampleRepository repository, ISystemInfoProvider infoProvider)
        {
            _repository = repository;
            _infoProvider = infoProvider;

            _repository.Initialize();
            Samples = new ObservableCollection<SystemSample>(_repository.LoadSamples());

            _interval = 1000; // ⚠️ Asignar directamente, sin usar el setter para evitar UpdateTimer()

            _timer = new Timer(_interval);
            _timer.Elapsed += (s, e) => CaptureSample();
        }


        public void ToggleCapture()
        {
            if (IsRunning) _timer.Stop();
            else _timer.Start();
            IsRunning = !IsRunning;
        }

        private void UpdateTimer()
        {
            _timer.Interval = Interval;
            if (IsRunning)
            {
                _timer.Stop();
                _timer.Start();
            }
        }

        private void CaptureSample()
        {
            var sample = new SystemSample
            {
                Timestamp = DateTime.Now,
                CpuSerial = _infoProvider.GetCpuSerial(),
                MotherboardSerial = _infoProvider.GetMotherboardSerial(),
                GpuSerial = _infoProvider.GetGpuSerial(),
                CpuUsage = _infoProvider.GetCpuUsage(),
                RamUsage = _infoProvider.GetRamUsage()
            };

            App.Current.Dispatcher.Invoke(() =>
            {
                Samples.Add(sample);
                _repository.SaveSample(sample);
            });
        }
    }
}
