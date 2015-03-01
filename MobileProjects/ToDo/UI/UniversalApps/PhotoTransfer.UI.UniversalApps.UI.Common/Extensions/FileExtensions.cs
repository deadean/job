using ToDo.UI.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.UI.UniversalApps.UI.Common.Extensions
{
	public static class FileExtensions
	{
		public static string ToPNGFileName(this string fileName)
		{
			return fileName.AddExtension(Constants.File.PNG_EXTENSION);
		}

		internal static string AddExtension(this string fileName, string extension)
		{
			return string.Format("{0}{1}", fileName, extension);
		}
	}
}
