using Windows.Media.Capture;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using ViewModel;
using Windows.UI.ViewManagement;
using Windows.Foundation;

namespace PhotoCapture
{
    /**
     * The MainPage for the app. The app starts from this page.
     */
    public sealed partial class MainPage : Page
    {
        /**
         * Constructor
         * It sets the DataContext and preferred app window size
         */
        public MainPage()
        {
            InitializeComponent();
            DataContext = new MainPageViewModel();

            // set preferred app window size
            ApplicationView.PreferredLaunchViewSize = new Size(540, 720);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;

            // set preferred minimum size
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(480, 640));

            Application.Current.Resuming += Application_Resuming;
        }

        /**
         * Set the default camera source
         * @param cameraSource The MediaCapture source that will be used to set the defaultCamera 
         */
        public void SetCameraSource(MediaCapture cameraSource)
        {
            defaultCamera.Source = cameraSource;
        }

        /**
         * Once the app is resumed the camera will be re-initialized
         * @param sender Sender object
         * @param o Object o
         */
        private async void Application_Resuming(object sender, object o)
        {
            await ((MainPageViewModel)this.DataContext).InitDefaultCameraAsync();
        }

        /**
         * When navigating to the the app the camera will be re=initialized
         * @param e NavigationEventArgs parameter
         */
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {

            await ((MainPageViewModel)this.DataContext).InitDefaultCameraAsync();
        }
    }
}
