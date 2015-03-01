using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Common.Implementations.Extensions;
using WebApi.Data.Implementations.Entities;
using WebApi.Data.Interfaces.QueryProcessors;
using WebApi.Web.Data.Implementations.Requests;
using WebApi.Web.Data.Implementations.Response;
using WebApi.WebApiService.Bases.Processing.Inquiry;
using WebApi.WebApiService.Interfaces.Processing.Inquiry;

namespace WebApi.WebApiService.Implementations.Processing
{
	public sealed class PhotoInquiryProcessor : BaseInquiryProcessorImpl, IPhotoInquiryProcessor
	{
		#region Fields

		private readonly IPhotoQueryProcessor modPhotoQueryProcessor;

		#endregion

		#region Ctor

		public PhotoInquiryProcessor(IPhotoQueryProcessor queryProcessor)
		{
			modPhotoQueryProcessor = queryProcessor;
		}

		#endregion

		#region Private Methods

		#endregion

		#region Public Methods

		public async Task<PhotoResponse> UploadPhoto(FileRequest fileRequest)
		{
			try
			{
				return await Task.Run(() =>
				{
					File.WriteAllBytes(fileRequest.UploadedFolder + fileRequest.FileName, fileRequest.FileData);
					//var user = modUserByLoginAndPasswordQueryProcessor.GetUserByLoginAndPassword(userName, userLogin);
					//var res = new UserResponse() { Function = user.Function, PersonID = user.PersonID, PostName = user.PostName, PreName = user.PreName };
					//return res;
					return new PhotoResponse();
				});
			}
			catch (Exception)
			{
				throw new Exception("Error was occurred when photo was uploading");
			}
		}


		public async Task<PhotoResponse> UploadMultiplyPhotoAndComment(MultiFileRequest fileRequest)
		{
			try
			{
				return await Task.Run(() =>
				{
					fileRequest.Files
						.ForEach(x => File.WriteAllBytes(x.UploadedFolder + x.FileName, x.FileData));

					var photoFile = fileRequest.Files.FirstOrDefault();
					//var commentFile = fileRequest.Files.LastOrDefault();
					
					var document = Document.CreateImageDocumentWithComment(
						Path.GetFileNameWithoutExtension(photoFile.FileName), 
						Path.GetExtension(photoFile.FileName).Trim('.'), 
						photoFile.FileData, 
						//System.Text.Encoding.UTF8.GetString(commentFile.FileData),
						photoFile.Comment,
						default(DateTime), 
						default(DateTime));

					modPhotoQueryProcessor.UploadDocument(document);

					return new PhotoResponse();
				});
			}
			catch (Exception)
			{
				throw new Exception("Error was occurred when photo was uploading");
			}
		}

		#endregion

		#region Protected Methods

		protected override void InitLog()
		{
			modLog = this.GetLog<PhotoInquiryProcessor>();
		}

		#endregion

		#region Properties
		#endregion

	}
}
