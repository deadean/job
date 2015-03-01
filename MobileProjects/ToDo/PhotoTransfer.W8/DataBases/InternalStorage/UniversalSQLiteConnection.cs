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
			if (!FileExists(PhotoTransfer.UI.Common.Constants.Constants.Configuration.csLocalDbFileName).Result)
			{
				return initDB();
			}
			return initDB();
		}

		private async Task<bool> FileExists(string fileName)
		{
			var result = false;
			try
			{
				var store = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
				result = true;
			}
			catch(Exception ex)
			{
			}

			return result;

		}
		public SQLiteAsyncConnection initDB()
		{
			try
			{
				var path = ApplicationData.Current.LocalFolder.Path + @"\"
					+ PhotoTransfer.UI.Common.Constants.Constants.Configuration.csLocalDbFileName;
				return new SQLiteAsyncConnection(path);
			}
			catch (Exception ex)
			{

			}
			return null;
		}
	}
}
