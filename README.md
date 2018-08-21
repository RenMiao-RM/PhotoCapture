# PhotoCapture App for Windows 10
PhotoCapture App for Windows 10

App Instruction:
PhotoCapture app can be used to preview the video from the webcam (on computers) or from the front-facing/rear-facing camera (on mobile devices). 
It has two modes: camera mode and photo viewer mode. In camera mode user can preview the video and click the "Save Photo" button to capture and save the photo to User\Pictures\Saved Pictures folder. To review the captured photos user can switch to Photo viewer mode by clicking "View Mode" button. In the viewer mode user can review the photos and delete unwanted photos. To switch back to camera mode simply click "Camera Mode" button. 

Code Structure:
MVVM pattern was followed. Model classes contain CameraDevice class and PhotoFile class. They represent the business logica and data. Views contain MainPage and PhotoViewer, which are UI presentation for Camera mode and PhotoViewer mode, respectively. Each view has its corresponding ViewModel classes, which contains UI presentation logic. ICommands were used to bind button-clicking event to its actions. Four commands (Delete/Save/View/Switch) were created.