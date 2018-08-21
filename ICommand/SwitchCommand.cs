using PhotoCapture;
using System;
using System.Windows.Input;
using ViewModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Commnds
{
    /**
     * SwitchCommand
     * SwitchCommand switch back from viewer mode to camera mode
     */
    public class SwitchCommand : ICommand
    {
        /// a private varialb efor PhotoViewerViewModel
        private PhotoViewerViewModel viewModel;

        /**
         * Constructor
         */
        public SwitchCommand(PhotoViewerViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        /// CanExecuteChanged EventHandler
        public event EventHandler CanExecuteChanged;

        /**
         * CanExecute method to determine if the command is active or inactive
         * @param parameter Parameter object
         * @return true if active, false otherwise; here always return true as switching between modes is always allowed
         */
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /**
         * Execute method
         * This command will switch from photo viewer mode to camera mode
         * @param parameter Parameter object
         */
        public void Execute(object parameter)
        {
            var frame = (Frame)Window.Current.Content;
            frame.Navigate(typeof(MainPage));
        }
    }
}
