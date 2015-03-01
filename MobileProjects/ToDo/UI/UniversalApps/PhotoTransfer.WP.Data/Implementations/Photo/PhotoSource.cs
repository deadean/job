using PhotoTransfer.Common.Implementations.Special;
using PhotoTransfer.Data.Interfaces.Photo;

using System;
using System.Threading.Tasks;

using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage;
using PhotoTransfer.UI.UniversalApps.Data.Implementations.File;


namespace PhotoTransfer.UI.UniversalApps.Data.Implementations.Photo
{
	public sealed class PhotoSource : StorageFileContainer, IPhotoSource
	{
		public object PhotoContainer { get; private set; }

		
		public PhotoSource(BitmapSource image, StorageFile file, bool isNew = true) : base(file, isNew)
		{
			PhotoContainer = image;
		}

		public PhotoSource(StorageFile file, bool isNew = true)
			: base(file, isNew)
		{
			PhotoContainer = null;
		}

		public static async Task<IPhotoSource> CreatePhotoSourceAsync(StorageFile file, bool isNew = true)
		{
			BitmapImage bitmapImage = new BitmapImage();

			using (var fileStream = await file.OpenReadAsync())
			{
				bitmapImage.SetSource(fileStream);
			}

			return new PhotoSource(bitmapImage, file, isNew);
		}
		
	}
}
