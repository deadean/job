using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Web.Common.Interfaces.DependencyBlock;
using WebApi.WebApiService.Interfaces.Processing.Inquiry;

namespace WebApi.WebApiService.Interfaces.DependencyBlock
{
	public interface IPhotoDependencyBlock : IDependencyBlock
	{
		IPhotoInquiryProcessor PhotoInquiryProcessor { get; }
	}
}
