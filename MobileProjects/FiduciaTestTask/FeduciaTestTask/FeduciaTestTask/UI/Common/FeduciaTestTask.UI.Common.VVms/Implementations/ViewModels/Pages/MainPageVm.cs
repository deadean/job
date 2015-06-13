using FeduciaTestTask.Services.Interfaces.Navigation;
using FeduciaTestTask.Services.Interfaces.WebService;
using FeduciaTestTask.UI.Common.Interfaces.DependencyBlocks;
using FeduciaTestTask.UI.Common.Interfaces.ViewModels;
using Library.Commands;
using Library.Types.Implemantions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeduciaTestTask.UI.Common.VVms.Implementations.ViewModels.Pages
{
	public class MainPageVm : ViewModelBase, IMainPageVm
	{

		#region Fields

		private readonly IWebService _webService;

		#endregion

		#region Properties

		public AsyncCommand SendRequestCommand { get; private set; }

		public ICustomNavigationService NavigationServiceCustom
		{
			get;
			private set;
		}


		#endregion

		#region Ctor

		public MainPageVm(IMainPageDependencyBlock mainPageDependencies)
		{
			_webService = mainPageDependencies.WebService;
			NavigationServiceCustom = mainPageDependencies.NavigationService;

			SendRequestCommand = new AsyncCommand(OnSendRequest);
		}



		#endregion

		#region Public Methods

		#endregion

		#region Private Methods

		private async Task OnSendRequest()
		{
			try
			{
				var modifications = await _webService.GetModificationsByCustomerCode("SCNCO");

				this.NavigationServiceCustom.NavigateTo<ModificationsPageVm>(modifications);

			}
			catch (Exception ex)
			{
			}
		}

		#endregion

		#region Protected Methods

		protected override void Initialize(object parameter)
		{
			throw new NotImplementedException();
		}

		#endregion



	}
}
