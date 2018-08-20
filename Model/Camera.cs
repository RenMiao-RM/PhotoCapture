using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Media.Capture;

namespace Model
{
    public class Camera
    {
        //private MediaCapture cameraCapture;
        public MediaCapture CameraCapture { get; set; }

        public Camera()
        {
            //InitCameraAsync();
        }

        public async Task<Camera> InitCameraAsync()
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

                //DefaultCamera.Source = CameraCapture;

                await CameraCapture.StartPreviewAsync();
            }

            return this;
        }

        public static Task<Camera> CreateAsync()
        {
            var result = new Camera();
            return result.InitCameraAsync();
        }

    }

}
