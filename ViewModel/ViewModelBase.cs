using System.ComponentModel;

namespace ViewModel
{
    /**
     * An abstract base class for all ViewModel classes.
     * It implements INotifyPropertyChanged interface
     */
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        /// event handler for PropertyChanged event.
        public event PropertyChangedEventHandler PropertyChanged;

        /**
         * fire the event to broadcast the property changes.
         * @param propertyName String for the property name that undergoes property changes. 
         */
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
