using NinjectService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Tests.Common.Bases
{
	public class BaseUnitTestControllerImpl : BaseUnitTestController
	{
		protected readonly INinjectService modNinjectService = new NinjectService.NinjectService();
		public BaseUnitTestControllerImpl()
		{
		}
		protected override void Initialize()
		{
			base.Initialize();
		}
	}
}
