using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace PhotoTransfer.UI.UniversalApps.Data.Extensions
{
	public static class DataExtensions
	{
		public static string GetParentDirectoryPath(this IStorageItem item)
		{
			return item.Path.Replace("\\" + item.Name, string.Empty);
		}
	}
}
