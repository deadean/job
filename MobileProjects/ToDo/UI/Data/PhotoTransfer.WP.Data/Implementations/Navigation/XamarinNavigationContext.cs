using GalaSoft.MvvmLight.Ioc;
using Library.Types;
using ToDo.Data.Interfaces.Navigation;
using ToDo.UI.Common.Interfaces.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ToDo.UI.Data.Implementations.Navigation
{
	public sealed class XamarinNavigationContext<T> : NavigationPage, INavigationContext<T>
	{
		private readonly NavigationPage modPage;
		public XamarinNavigationContext(NavigationPage page)
		{
			modPage = page;
		}

		public async Task PushAsync(T page)
		{
			try
			{
				await modPage.Navigation.PushAsync(page as Page);
			}
			catch (Exception ex)
			{

			}
		}
	}
}
