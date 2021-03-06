﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace ToDo.UI.UniversalApps.UI.Common.Implementations.Converters
{
	public class BoolToVisibilityInvertConverter : IValueConverter
	{
		/// <summary>
		/// If set to True, conversion is reversed: True will become Collapsed.
		/// </summary>
		public bool IsReversed { get; set; }

		public object Convert(object value, Type targetType, object parameter, string language)
		{
			var val = System.Convert.ToBoolean(value);
			if (this.IsReversed)
			{
				val = !val;
			}

			if (val)
			{
				return Visibility.Collapsed;
			}

			return Visibility.Visible;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}
}
