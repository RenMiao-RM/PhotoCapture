using PhotoCapture;
using System;
using System.Windows.Input;
using ViewModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Commnds
{
    public class SwitchCommand : ICommand
    {
        private PhotoViewerViewModel viewModel;

        public SwitchCommand(PhotoViewerViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var frame = (Frame)Window.Current.Content;
            frame.Navigate(typeof(MainPage));
        }
    }
}
