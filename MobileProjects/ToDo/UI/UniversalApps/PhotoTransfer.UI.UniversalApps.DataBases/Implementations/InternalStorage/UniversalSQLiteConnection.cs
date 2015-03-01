using ToDo.UI.DataBases.Implementations.InternalStorage;
using ToDo.UI.DataBases.Interfaces.DataBases;
using SQLite;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Attributes;
using SQLite.Net.Platform.WinRT;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace ToDo.UI.UniversalApps.Databases.Implementations.InternalStorage
{
	public class UniversalSQLiteConnection : ISQLiteConnection
	{
		public ConnectionInfo<SQLiteAsyncConnection> GetConnection()
		{
			ConnectionInfo<SQLiteAsyncConnection> connectionInfo = new ConnectionInfo<SQLiteAsyncConnection>();
			connectionInfo.IsInitializedDbStructure = true;

			if (!FileExists(ToDo.UI.Common.Constants.Constants.Configuration.csLocalDbFileName))
			{
				connectionInfo.IsInitializedDbStructure = false;	
			}

			connectionInfo.Connection = initDB();
			return connectionInfo;
		}

		private SQLiteAsyncConnection initDB()
		{
			try
			{
				var path = ApplicationData.Current.LocalFolder.Path + @"\"
					+ ToDo.UI.Common.Constants.Constants.Configuration.csLocalDbFileName;
				var plat = new SQLitePlatformWinRT();
				var connectionFactory = new Func<SQLiteConnectionWithLock>(() =>
					new SQLiteConnectionWithLock(plat, new SQLiteConnectionString(path, storeDateTimeAsTicks: false)));
				var connection = new SQLiteAsyncConnection(connectionFactory);

				return connection;
			}
			catch (Exception ex)
			{

			}
			return null;
		}

		private bool FileExists(string fileName)
		{
			var result = false;
			try
			{

				var store =
					Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
				//var store = await ApplicationData.Current.LocalFolder.GetItemAsync(fileName);
				result = true;
			}
			catch (Exception ex)
			{
			}

			return result;
		}

		
	}
}
