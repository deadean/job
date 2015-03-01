using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading.Tasks;
using Android.Graphics;
using Xamarin.Forms;
using ToDo.Driod.Data.ImageUtils;
using ToDo.UI.Common.Interfaces.Image;
using System.IO;

[assembly : Dependency(typeof(ImageLoader))]
namespace ToDo.Driod.Data.ImageUtils
{
	public class ImageLoader : IImageLoader
	{
		async Task<BitmapFactory.Options> GetBitmapOptionsOfImageAsync(string filePath)
		{
			BitmapFactory.Options options = new BitmapFactory.Options
			{
				InJustDecodeBounds = true
			};

			// The result will be null because InJustDecodeBounds == true.
			Bitmap result = await BitmapFactory.DecodeFileAsync(filePath, options);

			//int imageHeight = options.OutHeight;
			//int imageWidth = options.OutWidth;

			//_originalDimensions.Text = string.Format("Original Size= {0}x{1}", imageWidth, imageHeight);

			return options;
		}


		static int CalculateInSampleSize(BitmapFactory.Options options, int reqWidth, int reqHeight)
		{
			float height = options.OutHeight;
			float width = options.OutWidth;
			double inSampleSize = 1D;

			if (height > reqHeight || width > reqWidth)
			{
				int halfHeight = (int)(height / 2);
				int halfWidth = (int)(width / 2);
							
				while ((halfHeight / inSampleSize) > reqHeight && (halfWidth / inSampleSize) > reqWidth)
				{
					inSampleSize *= 2;
				}
			}

			return (int)inSampleSize;
		}

		public async Task<ImageSource> LoadImageSourceAsyncFromFile(string filePath, int reqWidth, int reqHeight)
		{
			var options = await GetBitmapOptionsOfImageAsync(filePath);
			options.InSampleSize = CalculateInSampleSize(options, reqWidth, reqHeight);
			options.InJustDecodeBounds = false;
			var bmp = await BitmapFactory.DecodeFileAsync(filePath, options);
			return ImageSource.FromStream(() =>
				{
					var memStream = new MemoryStream();
					bmp.Compress(Bitmap.CompressFormat.Jpeg, 100, memStream);
					return memStream;
				});
		}

		public Task<object> LoadImageSourceAsyncFromByteArray(byte[] imgData)
		{
			return Task.Run(() =>
			{
				var memory = new MemoryStream(imgData);
				var stream = ImageSource.FromStream(() => memory);
				return (object)stream;
			});
		}

		public Task<object> LoadImageSourceAsyncFromFile(string filePath)
		{
			return Task.Run(() => (object)ImageSource.FromFile(filePath));
		}


		//public static byte[] Resize2Max50Kbytes(byte[] byteImageIn)
		//{
		//	byte[] currentByteImageArray = byteImageIn;
		//	double scale = 1f;

		//	if (!IsValidImage(byteImageIn))
		//	{
		//		return null;
		//	}

		//	MemoryStream inputMemoryStream = new MemoryStream(byteImageIn);
		//	Image fullsizeImage = Image.FromStream(inputMemoryStream);

		//	while (currentByteImageArray.Length > 50000)
		//	{
		//		Bitmap fullSizeBitmap = new Bitmap(fullsizeImage, new Size((int)(fullsizeImage.Width * scale), (int)(fullsizeImage.Height * scale)));
		//		MemoryStream resultStream = new MemoryStream();

		//		fullSizeBitmap.Save(resultStream, fullsizeImage.RawFormat);

		//		currentByteImageArray = resultStream.ToArray();
		//		resultStream.Dispose();
		//		resultStream.Close();

		//		scale -= 0.05f;
		//	}

		//	return currentByteImageArray;
		//}

	}
}