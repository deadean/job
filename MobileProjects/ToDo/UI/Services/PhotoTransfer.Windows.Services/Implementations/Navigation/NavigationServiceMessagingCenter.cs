using Library.Types;
using ToDo.Data.Interfaces.Navigation;
using ToDo.UI.Common.Interfaces.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ToDo.WP.Services.Implementations.Navigation
{
	public class NavigationServiceMessagingCenter<T> : INavigationServiceCommon<T>
		where T : INavigationContext<ContentPage>
	{

		private T modNavigationContext;
		private readonly Dictionary<Type, Type> modContainer = new Dictionary<Type, Type>();

		public void SetNavigationContext(T navigationContext)
		{
			modNavigationContext = navigationContext;
		}

		public void Register<TVm, TView>()
			where TVm : IViewModel, INavigableAdvancedViewModelBase
			where TView : class
		{
			if (modContainer.ContainsKey(typeof(TVm)))
				return;

			modContainer.Add(typeof(TVm), typeof(TView));
		}

		public Task Navigate<TVm>() where TVm : IViewModel, INavigableAdvancedViewModelBase
		{
			throw new NotImplementedException();
		}

		public Task Navigate<TVm>(object parameter) where TVm : IViewModel, INavigableAdvancedViewModelBase
		{
			throw new NotImplementedException();
		}

		public async Task Navigate<TVm, TVmDestination, TArgs>(TVm sender, TArgs parameter)
			where TVmDestination : IViewModel, INavigableAdvancedViewModelBase
			where TVm : class, IViewModel, INavigableAdvancedViewModelBase
			where TArgs : class
		{
			Type type = typeof(TVmDestination);
			MessagingCenter.Send<TVm, TArgs>(sender, type.Name, parameter);
		}

		public async Task NavigateAsync<TVmSender, TVmDestination>(TVmSender sender)
			where TVmDestination : IViewModel, INavigableAdvancedViewModelBase
			where TVmSender : class, IViewModel, INavigableAdvancedViewModelBase
		{
			Type type = typeof(TVmDestination);
			MessagingCenter.Send<TVmSender>(sender, type.Name);
		}



	}
}
