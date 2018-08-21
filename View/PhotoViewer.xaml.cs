using ViewModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace PhotoCapture
{
    /**
     * PhotoViewer page class
     */
    public sealed partial class PhotoViewer : Page
    {
        /**
         * Constructor
         */
        public PhotoViewer()
        {
            this.InitializeComponent();
            DataContext = new PhotoViewerViewModel();

            Loaded += OnLoaded;
        }

        /**
         * OnLoaded method. 
         * This method will be called upon loading of this page
         * @param sender Sender object
         * @param e RoutedEventArgs parameter
         */
        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            PhotoViewerViewModel viewModel = (PhotoViewerViewModel)this.DataContext;
            await viewModel.InitViewerAsync();
        }
    }
}
