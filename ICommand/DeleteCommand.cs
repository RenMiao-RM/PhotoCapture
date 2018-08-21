using Model;
using System;
using System.Windows.Input;
using ViewModel;

namespace Commands
{
    /**
     * DeleteCommand
     * DeleteCommand deletes photo file
     */
    public class DeleteCommand : ICommand
    {
        /// a private variable for PhotoViewerViewModel
        private PhotoViewerViewModel viewModel;

        /**
         * Constructor
         */
        public DeleteCommand(PhotoViewerViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        /// CanExecuteChanged EventHandler
        public event EventHandler CanExecuteChanged;

        /**
         * CanExecute method to determine if the command is active or inactive
         * @param parameter Parameter object
         * @return true if active, false otherwise; here always return true as deleting a file is always allowed
         */
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /**
         * Execute DeleteCommand
         * Delete the corresponding photo file
         * @param parameter Parameter object; here it is is a PhotoFile object
         */
        public async void Execute(object parameter)
        {
            PhotoFile file = (PhotoFile)parameter;
            await file.File.DeleteAsync();
            viewModel.FileList.Remove(file);
            viewModel.UpdateFileList();
        }
    }
}
