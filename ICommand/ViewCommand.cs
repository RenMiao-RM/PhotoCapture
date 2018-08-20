using PhotoCapture;
using System;
using System.Windows.Input;
using ViewModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Commands
{
    public class ViewCommand : ICommand
    {
        MainPageViewModel viewModel;
        public ViewCommand(MainPageViewModel _viewModel)
        {
            viewModel = _viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var frame = (Frame)Window.Current.Content;
            frame.Navigate(typeof(PhotoViewer));
        }
    }
}
