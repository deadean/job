using ToDo.Common.Interfaces.Factories;
using ToDo.Data.Interfaces.Entities;
using ToDo.Services.DataBases.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoTransfer.Data.Interfaces.Entities;
using ToDo.UI.Data.Implementations.Entities;

namespace ToDo.UI.DataBases.Implementations.ModelService
{
	public class InternalModelService : IInternalModelService
	{

		#region Fields

		private readonly IInternalStorage modStorage;
		private readonly IObjectsByTypeFactory modFactoryObjects;

		#endregion

		#region Properties

		#endregion

		#region Ctor

		public InternalModelService(
			IInternalStorage storage
			, IObjectsByTypeFactory factory
			)
		{
			modStorage = storage;
			modFactoryObjects = factory;

			InitObjectsFactory();
		}

		

		

		#endregion

		#region Public Methods

		public Task SaveEntity<T>(T item) where T : IEntity, new()
		{
			return modStorage.Save<T>(item);
		}

		public Task UpdateEntityAsync<T>(T item) where T : IEntity, new()
		{
			return modStorage.Update<T>(item);
		}

		public Task Remove<T>(T item) where T : IEntity, new()
		{
			return modStorage.Remove<T>(item);
		}

		public Task<T> CreateEntity<T>()
		{
			return Task.Run(() => modFactoryObjects.GetObjectFromFactory<T>());
		}

		public Task<T> ItemById<T>(string id) where T : IEntity, new()
		{
			return modStorage.ItemById<T>(id);
		}

		public Task<List<T>> Items<T>() where T : IEntity, new()
		{
			return modStorage.Items<T>();
		}

		#endregion

		#region Private Methods

		private void InitObjectsFactory()
		{
			modFactoryObjects.RegisterObject<IToDo, ToDoItem>();
		}

		#endregion

		#region Protected Methods

		#endregion









		
	}
}
