using System;
using System.Windows;
using SystemMonitorApp.ViewModels;

namespace SystemMonitorApp
{
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _vm;

        public MainWindow(MainViewModel vm)
        {
            InitializeComponent();

            _vm = vm ?? throw new ArgumentNullException(nameof(vm));
            DataContext = _vm;
        }

        private void Toggle_Click(object sender, RoutedEventArgs e)
        {
            _vm.ToggleCapture();
        }

        private void Interval_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_vm == null) return;
            _vm.Interval = (int)e.NewValue;
        }
    }
}