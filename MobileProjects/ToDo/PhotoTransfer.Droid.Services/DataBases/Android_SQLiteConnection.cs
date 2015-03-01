using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ToDo.UI.DataBases.Implementations.InternalStorage;
using SQLite.Net;
using System.IO;
using Xamarin.Forms;
using ToDo.Droid.Services.DataBases;
using ToDo.UI.DataBases.Interfaces.DataBases;
using SQLite;
using SQLite.Net.Async;

[assembly: Dependency(typeof(Android_SQLiteConnection))]

namespace ToDo.Droid.Services.DataBases
{
	public class Android_SQLiteConnection : ISQLiteConnection
	{
		public ConnectionInfo<SQLiteAsyncConnection> GetConnection()
		{
			ConnectionInfo<SQLiteAsyncConnection> connectionInfo = new ConnectionInfo<SQLiteAsyncConnection>();
			connectionInfo.IsInitializedDbStructure = true;
			var sqliteFilename = ToDo.UI.Common.Constants.Constants.Configuration.csLocalDbFileName;
			string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); 
			var path = Path.Combine(documentsPath, sqliteFilename);

			if (!File.Exists(path))
			{
				var s = Forms.Context.Resources.OpenRawResource(Resource.Raw.adaica);
				FileStream writeStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
				ReadWriteStream(s, writeStream);
				connectionInfo.IsInitializedDbStructure = false;
			}

			var plat = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
			var connectionFactory = new Func<SQLiteConnectionWithLock>(() =>
				new SQLiteConnectionWithLock(plat, new SQLiteConnectionString(path, storeDateTimeAsTicks: false)));
			var asyncConnection = new SQLiteAsyncConnection(connectionFactory);
			connectionInfo.Connection = asyncConnection;

			return connectionInfo;
		}

		void ReadWriteStream(Stream readStream, Stream writeStream)
		{
			int Length = 256;
			Byte[] buffer = new Byte[Length];
			int bytesRead = readStream.Read(buffer, 0, Length);
			while (bytesRead > 0)
			{
				writeStream.Write(buffer, 0, bytesRead);
				bytesRead = readStream.Read(buffer, 0, Length);
			}
			readStream.Close();
			writeStream.Close();
		}
	}
}