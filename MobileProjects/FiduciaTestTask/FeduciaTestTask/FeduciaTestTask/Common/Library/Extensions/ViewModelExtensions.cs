using Library.Types.Implemantions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using XLabs.Forms.Mvvm;

/*
 * This code was copied from https://github.com/XLabs/Xamarin-Forms-Labs/issues/541
 */

namespace XLabs.Forms.Mvvm
{
	public static class ViewModelExtensions
	{
		public static void CallBundleMethod(this ViewModelBase viewModel, string methodName, object parameter)
		{
			var methods =viewModel.GetType().GetRuntimeMethods();
			var method = methods
					.Where(m => m.Name == methodName)
					.Where(m => !m.IsStatic)
					.FirstOrDefault();

			if (method != null)
			{
				viewModel.CallBundleMethod(method, parameter);
			}
		}

		public static void CallBundleMethod(this ViewModelBase viewModel, MethodInfo methodInfo, object parameter)
		{
			var parameters = methodInfo.GetParameters().ToArray();
			if (parameters.Count() == 1)
			{
				methodInfo.Invoke(viewModel, new object[] { parameter });
			}
		}
	}
}
