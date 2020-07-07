using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AsyncDemo.ViewModel
{
    /// <summary>
    /// Base view model
    /// </summary>
    /// <remarks>
    /// Implements INotifyPropertyChanged to clean up child view models
    /// Allows viewmodels to be switched for apps w/ multiple screens
    /// </remarks>
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Implementation

        /// <summary>
        /// Event handler for any property changes
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notifies a property has changed
        /// </summary>
        /// <param name="propertyName"> Name of the property (default: caller name) </param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}