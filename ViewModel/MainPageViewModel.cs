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
using Model;

namespace ViewModel
{
    /**
     * View model class for MainPage
     */
    public class MainPageViewModel : ViewModelBase
    {
        /// MediaCapture property
        //public MediaCapture CameraCapture { get; private set; }
        public CameraDevice DefaultCamera { get; private set; }
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
         * An async method to set the default camera and initialize the default camera
         */
        public async Task InitDefaultCameraAsync()
        {
            if (DefaultCamera == null)
            {
                var cameraDevices = await DeviceInformation.FindAllAsync(DeviceClass.VideoCapture);

                // here we use the first or default camera. If requirement changes we can change the camera by changing selection here
                DeviceInformation defaultWebCamDev = cameraDevices.FirstOrDefault();
                DefaultCamera = await CameraDevice.CreateNewCameraDeviceAsync(defaultWebCamDev);
            }

            if (DefaultCamera.CameraCapture == null)
            {
                await DefaultCamera.InitCameraAsync();
            }
        }      
    }
}

