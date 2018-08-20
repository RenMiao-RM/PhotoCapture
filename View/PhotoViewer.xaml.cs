using Model;
using System;
using ViewModel;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PhotoCapture
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PhotoViewer : Page
    {
        public PhotoViewer()
        {
            this.InitializeComponent();
            DataContext = new PhotoViewerViewModel();

            Loaded += OnLoaded;
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            PhotoViewerViewModel viewModel = (PhotoViewerViewModel)this.DataContext;
            viewModel.FileList.Clear();

            var files = await KnownFolders.SavedPictures.GetFilesAsync();

            foreach (var file in files)
            {
                var bitmap = new BitmapImage();

                using (var stream = await file.OpenReadAsync())
                {
                    await bitmap.SetSourceAsync(stream);
                }

                viewModel.FileList.Add(new PhotoFile(file, bitmap));
            }
        }
    }
}
