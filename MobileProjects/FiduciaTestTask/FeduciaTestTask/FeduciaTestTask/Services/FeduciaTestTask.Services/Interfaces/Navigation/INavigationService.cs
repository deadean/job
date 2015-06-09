using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeduciaTestTask.Services.Interfaces.Navigation
{
	public interface ICustomNavigationService
	{
		void NavigateTo(Type pageType, object parameter = null, bool animated = true);
		void NavigateTo<T>(object parameter = null, bool animated = true)
			where T : class;
	}
}
