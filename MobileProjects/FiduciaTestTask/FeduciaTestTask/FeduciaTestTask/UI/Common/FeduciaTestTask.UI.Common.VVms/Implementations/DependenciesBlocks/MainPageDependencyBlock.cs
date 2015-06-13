using FeduciaTestTask.Services.Interfaces.Navigation;
using FeduciaTestTask.Services.Interfaces.WebService;
using FeduciaTestTask.UI.Common.Interfaces.DependencyBlocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeduciaTestTask.UI.Common.VVms.Implementations.DependenciesBlocks
{
	public class MainPageDependencyBlock : IMainPageDependencyBlock
	{

		#region Fields

		#endregion

		#region Properties

		public IWebService WebService
		{
			get;
			private set;
		}

		public ICustomNavigationService NavigationService
		{
			get;
			private set;
		}

		#endregion

		#region Ctor

		public MainPageDependencyBlock(IWebService webService, ICustomNavigationService navigationService)
		{
			WebService = webService;
			NavigationService = navigationService;
		}

		#endregion

		#region Public Methods

		#endregion

		#region Private Methods

		#endregion

		#region Protected Methods

		#endregion

		
	}
}
