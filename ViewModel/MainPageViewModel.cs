using PhotoCapture;
using System;
using System.Linq;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Media.Capture;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Windows.Input;
using Commands;

namespace ViewModel
{
    /**
     * View model class for MainPage
     */
    public class MainPageViewModel : ViewModelBase
    {
        /// MediaCapture property
        public MediaCapture CameraCapture { get; private set; }
        /// SaveCommand - save photos
        public ICommand SaveCommand { get; set; }
        /// ViewCommand - switch to Viewer mode
        public ICommand ViewCommand { get; set; }

        /**
         * Constructor 
         */
        public MainPageViewModel()
        {
            SaveCommand = new SaveCommand(this);
            ViewCommand = new ViewCommand(this);
        }

        /**
         * An async method to initialize the camera
         */
        public async Task InitCameraAsync()
        {
            if (CameraCapture == null)
            {
                var cameraDevices = await DeviceInformation.FindAllAsync(DeviceClass.VideoCapture);

                var DefaultCamera = cameraDevices.FirstOrDefault();
                CameraCapture = new MediaCapture();

                await CameraCapture.InitializeAsync(
                    new MediaCaptureInitializationSettings
                    {
                        VideoDeviceId = DefaultCamera.Id
                    });

                var frame = (Frame)Window.Current.Content;
                var page = (MainPage)frame.Content;
                page.SetCameraSource(CameraCapture);

                await CameraCapture.StartPreviewAsync();
            }

        }      
    }
}

