using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModel;
using Windows.Media.MediaProperties;
using Windows.Storage;

namespace Commands
{ 
    public class SaveCommand : ICommand
    {
        MainPageViewModel viewModel;
        public SaveCommand(MainPageViewModel _viewModel)
        {
            viewModel = _viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {

            // Photo storage location (Picture/Saved Pictures)
            StorageFolder storageFolder = KnownFolders.SavedPictures;

            string targetFileName = await GenerateFileName(storageFolder);

            // Create the file 
            StorageFile file = await storageFolder.CreateFileAsync(targetFileName, CreationCollisionOption.ReplaceExisting);

            // Update the file with the contents of the photo
            await viewModel.CameraCapture.CapturePhotoToStorageFileAsync(ImageEncodingProperties.CreateJpeg(), file);
        }

        private async Task<String> GenerateFileName(StorageFolder folder)
        {
            string timeStamp = DateTime.Now.ToString("MM-dd-yyyy_hh-mm-ss_tt");

            IReadOnlyList<StorageFile> fileList = await folder.GetFilesAsync();
            bool containsFileName = false;
            int max = 0;
            foreach (StorageFile file in fileList)
            {
                if (file.Name.StartsWith(timeStamp))
                {
                    containsFileName = true;
                    int rightParenthesisIndex = file.Name.LastIndexOf(')');
                    int leftParenthesisIndex = file.Name.LastIndexOf('(');
                    if (rightParenthesisIndex < 0 || leftParenthesisIndex < 0)
                    {
                        continue;
                    }
                    string numInFile = file.Name.Substring(leftParenthesisIndex + 1, rightParenthesisIndex);
                    try
                    {
                        int num = Int32.Parse(numInFile);
                        max = Math.Max(max, num);
                    }
                    catch (FormatException e)
                    {
                        continue;
                    }
                }
            }

            if (!containsFileName)
                return timeStamp + ".jpg";
            else
                return timeStamp + "(" + (max + 1) + ")" + ".jpg";
        }
    }
}
