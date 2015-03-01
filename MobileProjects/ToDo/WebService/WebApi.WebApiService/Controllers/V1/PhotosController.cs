using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Common.Implementations.Logging;
using WebApi.Web.Common.Implementations.Controllers;
using WebApi.Web.Common.Implementations.FilterAttributes;
using WebApi.Web.Common.Routing;
using WebApi.Web.Data.Implementations.Constants;
using WebApi.Web.Data.Implementations.Requests;
using WebApi.WebApiService.Interfaces.DependencyBlock;
using WebApi.WebApiService.Interfaces.Processing.Inquiry;

namespace WebApi.WebApiService.Controllers.V1
{
	[ApiVersion1RoutePrefix("photos")]
	[UnitOfWorkAttribute]
	public class PhotosController : BaseController<IPhotoDependencyBlock>
	{
		#region Fields

		private readonly IPhotoInquiryProcessor modPhotoInquiryProcessor;
		private Common.Interfaces.Logging.ILogService modLogService;

		#endregion

		#region Ctor
		public PhotosController(IPhotoDependencyBlock dependencyBlock)
			: base(dependencyBlock)
		{
			modLogService = LogService.GetLogService<PhotosController>();
			modPhotoInquiryProcessor = dependencyBlock.PhotoInquiryProcessor;
		}
		#endregion

		#region Private Methods
		#endregion

		#region Public Get Methods
		[ResponseType(typeof(string))]
		[Route("", Name = "GetPhotos")]
		public async Task<IHttpActionResult> Get(HttpRequestMessage request)
		{
			var response = await Task.Run(() =>
			{
				return DateTime.Now.ToString();
			});
			return Ok(response);
		}

		public string Get(int id)
		{
			return "value";
		}
		#endregion

		#region Public Post Methods
		[ResponseType(typeof(IHttpActionResult))]
		[HttpPost]
		[Route("", Name = "SavePhoto")]
		public async Task<IHttpActionResult> SavePhoto()
		{
			try
			{
				await UploadMultiplyFiles();
				//await UploadSingleFile();
			}
			catch (Exception ex)
			{
				return this.BadRequest("File format not supported"+ex.Message);
			}
			return Ok("File has saved successfully");
		}

		#endregion

		#region Public Delete Methods
		public void Delete(int id)
		{
		}
		#endregion

		#region Public Put Methods
		#endregion

		#region Protected Methods
		#endregion

		#region Properties
		#endregion

		#region Private Methods

		private async Task UploadMultiplyFiles()
		{
			var provider = new MultipartMemoryStreamProvider();
			await Request.Content.ReadAsMultipartAsync(provider);
			string appDataFolder = HttpContext.Current.Server.MapPath("~/App_Data/");

			IList<FileRequest> requestedFiles = new List<FileRequest>();

			IList<FileRequestInfo> fileRequestInfo = new List<FileRequestInfo>();

			string fileComment = string.Empty;

			foreach (var file in provider.Contents)
			{
				string fileName = string.Empty;
				foreach (var item in file.Headers)
				{
					if (item.Key == Constants.csHeaderFileCommentParameterUploadedFile)
					{
						fileComment = item.Value.FirstOrDefault<string>();
						modLogService.Debug(fileComment);
					}
						
					if (item.Key == Constants.csHeaderFileNameParameterUploadedFile)
						fileName = item.Value.FirstOrDefault<string>();
				}

				try
				{
					fileName = string.IsNullOrWhiteSpace(fileName)
						? file.Headers.ContentDisposition.FileName.Trim('\"') : fileName;
				}
				catch (Exception) { }


				var buffer = await file.ReadAsByteArrayAsync();

				fileRequestInfo.Add(new FileRequestInfo() { Data = buffer, FileName = fileName });
			}

			fileComment = string.IsNullOrWhiteSpace(fileComment)
				? Request.Headers.GetValues(Constants.csHeaderFileCommentParameterUploadedFile).FirstOrDefault() : fileComment;

			foreach (var item in fileRequestInfo)
			{
				requestedFiles.Add(new FileRequest(item.FileName, item.Data, appDataFolder, fileComment));	
			}
			
			MultiFileRequest fileRequest = new MultiFileRequest(requestedFiles);
			await modPhotoInquiryProcessor.UploadMultiplyPhotoAndComment(fileRequest);
		}

		private async Task UploadSingleFile()
		{
			byte[] bytes = await Request.Content.ReadAsByteArrayAsync();
			string fileName = Request.Headers.GetValues("Filename").FirstOrDefault();
			string appDataFolder = HttpContext.Current.Server.MapPath("~/App_Data/");

			FileRequest fileRequest = new FileRequest(fileName, bytes, appDataFolder, "");
			await modPhotoInquiryProcessor.UploadPhoto(fileRequest);
		}

		private class FileRequestInfo
		{
			public byte[] Data { get; set; }
			public string FileName { get; set; }
		}

		#endregion

	}
}
