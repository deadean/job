using FeduciaTestTask.Services.Interfaces.Navigation;
using FeduciaTestTask.UI.Common.Interfaces.DependencyBlocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeduciaTestTask.UI.Common.VVms.Implementations.DependenciesBlocks
{
	public class ModificationsPageDependencyBlock : IModificationsPageDependnecyBlock
	{

		#region Fields

		#endregion

		#region Properties

		public ICustomNavigationService NavigationService
		{
			get;
			private set;
		}

		#endregion

		#region Ctor

		public ModificationsPageDependencyBlock(ICustomNavigationService navigationService)
		{
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
