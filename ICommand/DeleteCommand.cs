using Model;
using System;
using System.Windows.Input;
using ViewModel;

namespace Commands
{
    public class DeleteCommand : ICommand
    {
        public PhotoViewerViewModel ViewModel { get; set; }

        public DeleteCommand(PhotoViewerViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            PhotoFile file = (PhotoFile)parameter;
            await file.File.DeleteAsync();
            ViewModel.FileList.Remove(file);
            ViewModel.UpdateFileList();
        }
    }
}
