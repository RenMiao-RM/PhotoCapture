using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;
using System;

namespace Model
{
    /**
     * PhotoFile class
     */
    public class PhotoFile
    {
        /// Image property
        public BitmapImage Image { get; set; }

        /// File property
        public StorageFile File { get; set; }

        /**
         * Constructor
         * @param file Storage File
         */
        public PhotoFile(StorageFile file)
        {
            File = file;
        }

        /**
         * Generate BitmapImage according to File
         */
        private async Task GenerateImageAsync()
        {
            BitmapImage bitmap = new BitmapImage();

            using (var stream = await File.OpenReadAsync())
            {
                await bitmap.SetSourceAsync(stream);
            }

            Image = bitmap;
        }

        /**
         * A public factory method for generating new PhotoFile object
         * Note: constructor can not call async method, therefore a static factory method is needed.
         * @param file StorageFile
         */
        public static async Task<PhotoFile> GeneratePhotoFile(StorageFile file)
        {
            PhotoFile photo = new PhotoFile(file);
            await photo.GenerateImageAsync();
            return photo;
        }
    }
}
