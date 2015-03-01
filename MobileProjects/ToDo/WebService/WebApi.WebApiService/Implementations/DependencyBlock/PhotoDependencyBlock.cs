using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.WebApiService.Interfaces.DependencyBlock;
using WebApi.WebApiService.Interfaces.Processing.Inquiry;

namespace WebApi.WebApiService.Implementations.DependencyBlock
{
	public sealed class PhotoDependencyBlock : IPhotoDependencyBlock
	{
		public IPhotoInquiryProcessor PhotoInquiryProcessor { get; private set; }

		public PhotoDependencyBlock(IPhotoInquiryProcessor photoInquiryProcessor)
		{
			PhotoInquiryProcessor = photoInquiryProcessor;
		}
	}
}
