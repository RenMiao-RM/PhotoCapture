using Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Commnds;
using Commands;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Windows.Storage;

namespace ViewModel
{
    /**
     * View model for PhotoViewer page
     */
    public class PhotoViewerViewModel : ViewModelBase
    {
        /// List of photo files for the viewer
        public ObservableCollection<PhotoFile> FileList { get; set; }
        /// DeleteCommand - Delete file
        public ICommand DeleteCommand { get; set; }

        /// SwitchCommand - switch to camera mode
        public ICommand SwitchCommand { get; set; }

        /**
         * Constructor
         */
        public PhotoViewerViewModel()
        {
            DeleteCommand = new DeleteCommand(this);
            SwitchCommand = new SwitchCommand(this);
            FileList = new ObservableCollection<PhotoFile>();
        }

        /**
         * Initialize the photo viewer page
         */
        internal async Task InitViewerAsync()
        {
            FileList.Clear();

            IReadOnlyList<StorageFile> files = await KnownFolders.SavedPictures.GetFilesAsync();

            foreach (StorageFile file in files)
            {
                PhotoFile newPhotoFile = await PhotoFile.GeneratePhotoFile(file);
                FileList.Add(newPhotoFile);
            }
        }

        /**
         * A public method to notify the chagne of FileList
         */
        public void UpdateFileList()
        {
            OnPropertyChanged("FileList");
        }
    }
}
