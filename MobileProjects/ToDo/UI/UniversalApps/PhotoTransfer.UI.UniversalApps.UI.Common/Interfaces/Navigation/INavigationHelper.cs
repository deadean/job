using GalaSoft.MvvmLight.Command;
using ToDo.UI.UniversalApps.UI.Common.Implementations.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace ToDo.UI.UniversalApps.UI.Common.Interfaces.Navigation
{
	public interface INavigationHelper : Library.Types.INavigationHelper
	{
		void SetNavigableContext(Page page);

		event LoadStateEventHandler LoadState;
		event SaveStateEventHandler SaveState;

		void OnNavigatedTo(NavigationEventArgs e);
		void OnNavigatedFrom(NavigationEventArgs e);
	}
	public delegate void LoadStateEventHandler(object sender, LoadStateEventArgs e);
	public delegate void SaveStateEventHandler(object sender, SaveStateEventArgs e);
}
