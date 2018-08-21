using System;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModel;
using Windows.Data.Xml.Dom;
using Windows.Media.MediaProperties;
using Windows.Storage;
using Windows.UI.Notifications;

namespace Commands
{
    /**
     * SaveCommand class
     * SaveCommand save the current photo on camera to Picture/Saved Pictures folder
     */
    public class SaveCommand : ICommand
    {
        /// A private variable for MainPageViewModel
        private MainPageViewModel viewModel;

        private XmlDocument notificationXML;

        /**
         * Constructor
         */
        public SaveCommand(MainPageViewModel viewModel)
        {
            this.viewModel = viewModel;

            string notificationStr = "<toast launch=\"app-defined-string\">" +
                         "<visual>" +
                           "<binding template =\"ToastGeneric\">" +
                             "<text>PhotoCapture Notification</text>" +
                             "<text>" +
                               @"Photo captured and saved at \Users\Pictures\Saved Pictures folder. " +
                             "</text>" +
                           "</binding>" +
                         "</visual>" +
                       "</toast>";

            // load the template as XML document
            notificationXML = new XmlDocument();
            notificationXML.LoadXml(notificationStr);
        }

        /// CanExecuteChanged EventHanlder
        public event EventHandler CanExecuteChanged;

        /**
         * CanExecute method to determine if the command is active or inactive
         * @param parameter Parameter object
         * @return true if active, false otherwise; here always return true as saving a photo is always allowed
         */
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /**
         * Execute the SaveCommand saves the current photo on camera to Pictures/Saved Pictures folder.
         * @param parameter Parameter object
         */
        public async void Execute(object parameter)
        {
            // Photo storage location (Picture/Saved Pictures)
            StorageFolder storageFolder = KnownFolders.SavedPictures;

            // Create the file (an uniquie name will be generated)
            StorageFile file = await storageFolder.CreateFileAsync(GenerateFileName(), CreationCollisionOption.GenerateUniqueName);

            // Update the file with the contents of the photo
            await viewModel.DefaultCamera.CameraCapture.CapturePhotoToStorageFileAsync(ImageEncodingProperties.CreateJpeg(), file);

            // create the toast notification and show to user
            var toastNotification = new ToastNotification(notificationXML);
            var notification = ToastNotificationManager.CreateToastNotifier();
            notification.Show(toastNotification);

            // delay for 1 second and hide the notification
            await Task.Delay(TimeSpan.FromSeconds(1));
            notification.Hide(toastNotification);

        }

        /**
         * A method to generate the file name. 
         * The file name has the following format: MM-dd-yyyy_hh-mm-ss_tt (tt is AM or PM).
         * In the CreateFileAsync() call above it uses GenerateUniqueName option therefore all file names will be unique.
         * @return generated file name
         */
        private string GenerateFileName()
        {
            string timeStamp = DateTime.Now.ToString("MM-dd-yyyy_hh-mm-ss_tt");
            return timeStamp + ".jpg";
        }
    }
}
