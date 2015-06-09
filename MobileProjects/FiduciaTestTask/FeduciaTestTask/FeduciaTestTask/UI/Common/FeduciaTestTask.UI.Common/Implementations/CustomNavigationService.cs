using FeduciaTestTask.Services.Interfaces.Navigation;
using Library.Types.Implemantions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XLabs.Forms.Mvvm;
using XLabs.Forms.Services;
using XLabs.Platform.Services;

namespace FeduciaTestTask.UI.Common.Implementations
{
	public class CustomNavigationService: ICustomNavigationService
	{

		#region Fields

		private readonly INavigationService _navigationService;

		#endregion

		#region Properties

		#endregion

		#region Ctor

		public CustomNavigationService(INavigationService navService)
		{
			_navigationService = navService;
		}

		#endregion

		#region Public Methods

		public void NavigateTo(Type pageType, object parameter = null, bool animated = true)
		{
			_navigationService.NavigateTo(pageType, parameter, animated);

			var navigation = Xamarin.Forms.Application.Current.MainPage.Navigation;

			var page = navigation.NavigationStack.Last();
			var vm = (page.BindingContext as ViewModelBase);
			vm.CallBundleMethod("Initialize", parameter);
		}

		public void NavigateTo<T>(object parameter = null, bool animated = true)
			where T : class
		{
			_navigationService.NavigateTo<T>(parameter, animated);

			var navigation = Xamarin.Forms.Application.Current.MainPage.Navigation;

			var page = navigation.NavigationStack.Last();
			var vm = (page.BindingContext as ViewModelBase);
			vm.CallBundleMethod("Initialize", parameter);
		}

		#endregion

		#region Private Methods

		#endregion

		#region Protected Methods

		#endregion
		

		
	}
}
