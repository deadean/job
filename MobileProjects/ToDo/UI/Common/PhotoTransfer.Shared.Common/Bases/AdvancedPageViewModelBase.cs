using GalaSoft.MvvmLight.Ioc;
using Library.Commands;
using Library.Types;
using ToDo.UI.Common.Interfaces.Navigation;
using System.Threading.Tasks;

namespace ToDo.UI.Common.Bases
{
	public abstract class AdvancedPageViewModelBase : AdvancedViewModelBase, INavigableAdvancedViewModelBase
	{
		#region Fields

		private readonly AsyncCommand mvBackCommand;
		protected readonly INavigationServiceCommon modNavigationService;
		private object mvNavigationParameter;
		private INavigationHelper modNavigationHelper;

		#endregion
		#region Ctor

		protected AdvancedPageViewModelBase()
		{
			modNavigationService = SimpleIoc.Default.GetInstance<INavigationServiceCommon>();
			mvBackCommand = new AsyncCommand(OnBackCommand);
		}

		

		#endregion
		#region Private Methods

		#endregion
		#region Public Methods

		public void SetNavigationHelper(INavigationHelper navigationHelper)
		{
			modNavigationHelper = navigationHelper;
		}

		#endregion
		#region Protected Methods

		protected virtual async Task OnNavigationParameterChanged(object navigationParameter) {  }

		#endregion
		#region Dependency Properties
		#endregion
		#region Properties

		public virtual object NavigationParameter 
		{
			get { return mvNavigationParameter; }
			set
			{
				mvNavigationParameter = value;
				this.OnNavigationParameterChanged(mvNavigationParameter);
			}
		}

		#endregion
		#region Commands

		public AsyncCommand BackCommand
		{
			get { return mvBackCommand; }
		}


		#endregion
		#region Commands Execute Handlers

		private async Task OnBackCommand()
		{
			modNavigationHelper.GoBackCommand.Execute(null);
		}

		#endregion
		#region Commands Can Execute Handlers
		#endregion
		#region Message Handlers
		#endregion
		#region Events Handlers
		#endregion




		
	}
}
