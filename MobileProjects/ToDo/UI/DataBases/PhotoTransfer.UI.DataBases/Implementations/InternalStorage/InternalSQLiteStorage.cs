using ToDo.Data.Interfaces.Entities;
using ToDo.Services.DataBases.Interfaces;
using ToDo.UI.DataBases.Interfaces.DataBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ToDo.UI.DataBases.Implementations.InternalStorage
{
	public sealed class InternalSQLiteStorage : IInternalStorage
	{

		#region Fields

		private static object locker = new object();

		private ISQLiteDataAccessService modDataAccessService;
		//private Dictionary<Type, List<IEntity>> modCache;

		#endregion

		#region Properties

		#endregion

		#region Ctor

		public InternalSQLiteStorage(ISQLiteDataAccessService connection)
		{
			modDataAccessService = connection;
			//modCache = new Dictionary<Type, List<IEntity>>();
		}

		#endregion

		#region Public Methods

		public async Task Save<T>(T item) where T : IEntity, new()
		{
			await modDataAccessService.Save<T>(item);
		}

		public async Task Update<T>(T item) where T : IEntity, new()
		{
			await modDataAccessService.Update<T>(item);
		}

		public Task Remove<T>(T item) where T : IEntity, new()
		{
			return modDataAccessService.Remove<T>(item);
		}

		public async Task<List<T>> Items<T>() where T : IEntity, new()
		{
			return await modDataAccessService.Items<T>();
		}

		public Task<T> ItemById<T>(string id) where T : IEntity, new()
		{
			return modDataAccessService.ItemById<T>(id);
		}

		#endregion

		#region Private Methods

		#endregion

		#region Protected Methods

		#endregion









		
	}
}
