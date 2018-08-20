using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;

namespace Model
{
    public class PhotoFile
    {
        public BitmapImage Image { get; set; }
        public StorageFile File { get; set; }

        public PhotoFile(StorageFile file, BitmapImage image)
        {
            Image = image;
            File = file;
        }
    }
}
