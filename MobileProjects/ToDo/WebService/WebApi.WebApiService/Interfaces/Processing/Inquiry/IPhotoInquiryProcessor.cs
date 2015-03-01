using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Web.Data.Implementations.Requests;
using WebApi.Web.Data.Implementations.Response;

namespace WebApi.WebApiService.Interfaces.Processing.Inquiry
{
	public interface IPhotoInquiryProcessor
	{
		Task<PhotoResponse> UploadPhoto(FileRequest fileRequest);
		Task<PhotoResponse> UploadMultiplyPhotoAndComment(MultiFileRequest fileRequest);
	}
}
