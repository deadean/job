using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.UI.UniversalApps.UI.Common.Implementations.Navigation
{
	public class LoadStateEventArgs : EventArgs
	{
		/// <summary>
		/// The parameter value passed to <see cref="Frame.Navigate(Type, Object)"/> 
		/// when this page was initially requested.
		/// </summary>
		public Object NavigationParameter { get; private set; }
		/// <summary>
		/// A dictionary of state preserved by this page during an earlier
		/// session.  This will be null the first time a page is visited.
		/// </summary>
		public Dictionary<string, Object> PageState { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="LoadStateEventArgs"/> class.
		/// </summary>
		/// <param name="navigationParameter">
		/// The parameter value passed to <see cref="Frame.Navigate(Type, Object)"/> 
		/// when this page was initially requested.
		/// </param>
		/// <param name="pageState">
		/// A dictionary of state preserved by this page during an earlier
		/// session.  This will be null the first time a page is visited.
		/// </param>
		public LoadStateEventArgs(Object navigationParameter, Dictionary<string, Object> pageState)
			: base()
		{
			this.NavigationParameter = navigationParameter;
			this.PageState = pageState;
		}
	}
}
