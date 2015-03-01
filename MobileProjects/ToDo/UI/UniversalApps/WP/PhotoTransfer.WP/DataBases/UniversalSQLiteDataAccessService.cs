using PhotoTransfer.Data.Interfaces.Entities;
using PhotoTransfer.UI.Data.Implementations.Entities.Photo;
using PhotoTransfer.UI.DataBases.Interfaces.DataBases;
using PhotoTransfer.UI.UniversalApps.Services.Implementations.DataBases.InternalStorage;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTransfer.UI.UniversalApps.DataBases.Implementations.DataBases
{
	public class UniversalSQLiteDataAccessService : ISQLiteDataAccessService
	{
		#region Fields

		private readonly SQLiteAsyncConnection modConnection;

		#endregion

		#region Properties

		#endregion

		#region Ctor

		public UniversalSQLiteDataAccessService()
		{
			modConnection = new UniversalSQLiteConnection().GetConnection();
			modConnection.CreateTableAsync<Photo>();
			modConnection.CreateTableAsync<Comment>();
		}

		#endregion

		#region Public Methods

		public async Task Save<T>(T item) where T : IEntity, new()
		{
			await modConnection.UpdateAsync(item);
		}

		public async Task<List<T>> Items<T>() where T : IEntity, new()
		{
			return await modConnection.Table<T>().ToListAsync();
		}

		#endregion

		#region Private Methods

		#endregion

		#region Protected Methods

		#endregion

	}
}
