using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SystemMonitorApp.Core.MVVM
{
    /// <summary>
    /// Clase base para ViewModels, implementa INotifyPropertyChanged.
    /// Permite la actualización automática de bindings en la UI.
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notifica a la vista que una propiedad ha cambiado.
        /// </summary>
        /// <param name="propertyName">Nombre de la propiedad</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}