using ToDo.UI.DataBases.Implementations.InternalStorage;
using ToDo.UI.DataBases.Interfaces.DataBases;
using ToDo.WinPhone.Implementations.DataBases;
using SQLite;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Platform.WindowsPhone8;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(WinPhone_SQLiteConnection))]

namespace ToDo.WinPhone.Implementations.DataBases
{
	public class WinPhone_SQLiteConnection : ISQLiteConnection
	{
		public ConnectionInfo<SQLiteAsyncConnection> GetConnection()
		{
			ConnectionInfo<SQLiteAsyncConnection> connectionInfo = new ConnectionInfo<SQLiteAsyncConnection>();
			connectionInfo.IsInitializedDbStructure = true;

			var sqliteFilename = ToDo.UI.Common.Constants.Constants.Configuration.csLocalDbFileName;
			string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);

			if (!System.IO.File.Exists(path))
			{
				connectionInfo.IsInitializedDbStructure = false;
			}

			var plat = new SQLitePlatformWP8();
			var connectionFactory = new Func<SQLiteConnectionWithLock>(() =>
				new SQLiteConnectionWithLock(plat, new SQLiteConnectionString(path, storeDateTimeAsTicks: false)));
			var asyncConnection = new SQLiteAsyncConnection(connectionFactory);
			connectionInfo.Connection = asyncConnection;

			return connectionInfo;
		}

		private async Task<bool> FileExists(string fileName)
		{
			var result = false;
			try
			{
				var store = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
				result = true;
			}
			catch (Exception ex)
			{
			}

			return result;
		}
	}
}
