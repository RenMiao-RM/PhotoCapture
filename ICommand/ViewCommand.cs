using PhotoCapture;
using System;
using System.Windows.Input;
using ViewModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Commands
{
    /**
     * ViewCommand class
     * ViewCommand switch from camera mode to viewer mode
     */
    public class ViewCommand : ICommand
    {
        /// A private variable for MainPageViewModel
        private MainPageViewModel viewModel;
        
        /**
         * Constructor
         */
        public ViewCommand(MainPageViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        /// CanExecuteChanged EventHandler
        public event EventHandler CanExecuteChanged;

        /**
         * CanExecute method to determine if the command is active or inactive
         * @param parameter Parameter object
         * @return true if active, false otherwise; here always return true as switching to viewer mode is always allowed
         */
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /**
         * Execute method
         * This command will switch from camera mode to photo viewer mode
         * @param parameter Parameter object
         */
        public void Execute(object parameter)
        {
            var frame = (Frame)Window.Current.Content;
            frame.Navigate(typeof(PhotoViewer));
        }
    }
}
