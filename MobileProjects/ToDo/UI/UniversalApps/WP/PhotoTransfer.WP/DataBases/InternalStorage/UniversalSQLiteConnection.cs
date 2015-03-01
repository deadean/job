using PhotoTransfer.UI.DataBases.Implementations.InternalStorage;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace PhotoTransfer.UI.UniversalApps.Services.Implementations.DataBases.InternalStorage
{
	public class UniversalSQLiteConnection
	{
		public SQLiteAsyncConnection GetConnection()
		{
			try
			{
				if (!CheckFileExists(PhotoTransfer.UI.Common.Constants.Constants.Configuration.csLocalDbFileName).Result)
				{
					return new SQLiteAsyncConnection(PhotoTransfer.UI.Common.Constants.Constants.Configuration.csLocalDbFileName);
				}
				return new SQLiteAsyncConnection(PhotoTransfer.UI.Common.Constants.Constants.Configuration.csLocalDbFileName);
			}
			catch
			{
			}
			return null;
		}

		private async Task<bool> CheckFileExists(string fileName)
		{
			try
			{
				var store = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}
