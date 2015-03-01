using ToDo.UI.Common.Interfaces.Image;
using ToDo.WinPhone.Implementations.ImageLoader;
using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using Xamarin.Forms;

[assembly : Dependency(typeof(ImageLoader))]

namespace ToDo.WinPhone.Implementations.ImageLoader
{
	public class ImageLoader : IImageLoader
	{
		public Task<object> LoadImageSourceAsyncFromByteArray(byte[] imgData)
		{
			return Task.Run<object>(() => ImageSource.FromStream(() => new MemoryStream(imgData)));
		}

		public async Task<object> LoadImageSourceAsyncFromFile(string filePath)
		{
			using (var streamReader = new StreamReader(filePath))
			{
				var memoryStream = new MemoryStream();
				await streamReader.BaseStream.CopyToAsync(memoryStream);
				return ImageSource.FromStream(() => memoryStream);
			}			
		}
	}
}
