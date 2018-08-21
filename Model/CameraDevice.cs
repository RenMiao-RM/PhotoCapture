using PhotoCapture;
using System;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Media.Capture;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Model
{
    /**
     * A mdoel class represeting Camera Device
     */
    public class CameraDevice
    {
        /// DeviceInfo property
       public DeviceInformation DeviceInfo { get; private set; }

        /// CamereaCapture property
        public MediaCapture CameraCapture { get; private set; }

        /**
         * Constructor
         * @param cameraDeviceInfo 
         */
        public CameraDevice(DeviceInformation cameraDeviceInfo)
        {
            DeviceInfo = cameraDeviceInfo;
        }

        /**
         * An async method to Initialize the camera
         */
        public async Task InitCameraAsync()
        {
            if (CameraCapture == null)
            {
                CameraCapture = new MediaCapture();

                await CameraCapture.InitializeAsync(
                    new MediaCaptureInitializationSettings
                    {
                        VideoDeviceId = DeviceInfo.Id
                    });

                var frame = (Frame)Window.Current.Content;
                var page = (MainPage)frame.Content;
                page.SetCameraSource(CameraCapture);

                await CameraCapture.StartPreviewAsync();
            }
        }

        /**
         * A static factory method to generate new CameraDevice object
         * @param cameraDevice DeviceInformation for the camera device
         */
        public static async Task<CameraDevice> CreateNewCameraDeviceAsync(DeviceInformation cameraDevice)
        {
            CameraDevice dev = new CameraDevice(cameraDevice);
            await dev.InitCameraAsync();
            return dev;
        }
    }
}
