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
using ToDo.Services.WebService.Interfaces;
using System.Net;
using System.Threading.Tasks;
using Xamarin.Forms;
using ToDo.Droid.Services.Implementations.WebService;

using Configuration = ToDo.UI.Common.Constants.Constants.Configuration;
using System.Net.Http;
using System.IO;
using System.Net.Http.Headers;
using ToDo.Data.Interfaces.Entities.Photo;
using ToDo.Data.Interfaces.File;

[assembly: Dependency(typeof(Android_WebService))]

namespace ToDo.Droid.Services.Implementations.WebService
{
	public class Android_WebService : IWebService
	{
		public async Task UploadPhoto(IFileSource fileSource, IComment comment)
		{
			try
			{
				var multi = new MultipartContent();
				var imageContent = new StreamContent(new FileStream(fileSource.FilePath, FileMode.Open, FileAccess.Read, FileShare.Read));
				imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");

				imageContent.Headers
					.Add(ToDo.Common.Constants.Constants.Configuration.csHeaderFileNameParameterUploadedFile, fileSource.FullName);
				imageContent.Headers.Add(ToDo.Common.Constants.Constants.Configuration.csHeaderFileCommentParameterUploadedFile
					,comment.Comment);
				multi.Add(imageContent);

				var client = new System.Net.Http.HttpClient();
				client.BaseAddress = new Uri(Configuration.csWebServerLoadPhotoUrl);
				var result = client.PostAsync(string.Empty, multi).Result;

			}
			catch (Exception ex)
			{

			}
		}

		//WebClient Client = new WebClient();
		//Client.Headers.Add("Filename", "test.png");
		////Client.Headers.Add("Comment", "Hello from Android");
		//byte[] result =
		//	await Client.UploadFileTaskAsync(Configuration.csWebServerLoadPhotoUrl, "POST", filePath);
	}
}