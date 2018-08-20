using Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Commnds;
using Commands;

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
         * A public method to notify the chagne of FileList
         */
        public void UpdateFileList()
        {
            OnPropertyChanged("FileList");
        }
    }
}
