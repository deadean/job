using ToDo.Services.DataBases.Interfaces;
using ToDo.UI.Common.Interfaces.DependencyBlock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.UI.Common.VVms.Implementations.DependencyBlock
{
	public class MainPageDependencyBlock : IMainPageDependencyBlock
	{
		private readonly IInternalModelService modModelService;

		public MainPageDependencyBlock(
			IInternalModelService modelService)
		{
			modModelService = modelService;
		}

		public IInternalModelService ModelService
		{
			get { return modModelService; }
		}
	}
}
