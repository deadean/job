using ToDo.Data.Interfaces.Entities;
using ToDo.UI.DataBases.Interfaces.DataBases;
using SQLite;
using SQLite.Net.Async;
using SQLiteNetExtensionsAsync.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.UI.Data.Implementations.Entities;

namespace ToDo.UI.DataBases.Implementations.InternalStorage
{
	public class SQLiteDataAccessService : ISQLiteDataAccessService
	{

		#region Fields

		private readonly SQLiteAsyncConnection modConnection;

		#endregion

		#region Properties

		#endregion

		#region Ctor

		public SQLiteDataAccessService(ISQLiteConnection connection)
		{
			try
			{
				ConnectionInfo<SQLiteAsyncConnection> connectionInfo = connection.GetConnection();
				modConnection = connectionInfo.Connection;
				if (connectionInfo.IsInitializedDbStructure)
					return;

				InitDataBase();
			}
			catch (Exception ex)
			{

			}
		}

		#endregion

		#region Public Methods

		public async Task Save<T>(T item) where T : IEntity, new()
		{
			await modConnection.InsertAsync(item);
			await modConnection.UpdateWithChildrenAsync(item);
		}

		public async Task Update<T>(T item) where T : IEntity, new()
		{
			await modConnection.InsertOrReplaceWithChildrenAsync(item);
			//await modConnection.UpdateWithChildrenAsync(item);
		}

		public async Task<List<T>> Items<T>() where T : IEntity, new()
		{
			var res = await modConnection.GetAllWithChildrenAsync<T>();
			return res;
		}

		public Task<T> ItemById<T>(string id) where T : IEntity, new()
		{
			return modConnection.GetAsync<T>((item) => item.IdEntity == id);
		}

		#endregion

		#region Private Methods

		private async void InitDataBase()
		{
			await modConnection.DropTableAsync<ToDoItem>();

			await modConnection.CreateTableAsync<ToDoItem>();
		}

		#endregion

		#region Protected Methods

		#endregion













		
	}
}
