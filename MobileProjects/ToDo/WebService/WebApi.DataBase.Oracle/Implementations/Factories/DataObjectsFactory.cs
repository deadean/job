using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Data.Entities.Interfaces;
using WebApi.Data.Implementations.Constants;
using WebApi.Data.Implementations.Entities;
using WebApi.Data.Interfaces.Entities;
using WebApi.DataBase.Oracle.Interfaces.Factories;

namespace WebApi.DataBase.Oracle.Implementations.Factories
{
	public class DataObjectsFactory : IDataObjectsFactory
	{
		#region Fields

		private Dictionary<string, Func<object, object>> modFactoryObjects = new Dictionary<string, Func<object, object>>();

		#endregion

		#region Ctor

		public DataObjectsFactory()
		{			
			//RegisterFactoryObject<Phone>(ConstantsEntity.csPhone);
			//RegisterFactoryObject<Email>(ConstantsEntity.csEmail);

			//RegisterFactoryObject<Guardian>(ConstantsEntity.csGuardian);
			//RegisterFactoryObject<Student>(ConstantsEntity.csStudent);
		}

		#endregion

		#region Private Methods
		#endregion

		#region Public Methods

		public void RegisterFactoryObject<T>(string key) where T : new()
		{
			modFactoryObjects.Add(key, (o) => { return new T(); });
		}

		public void RegisterFactoryObject<T>(string key, Func<object> func)
		{
			if (!modFactoryObjects.ContainsKey(key))
			{
				modFactoryObjects.Add(key, (o) => func);
				return;
			}

			modFactoryObjects[key] = (o) => func;
		}

		public void RegisterFactoryObject<T, R>(string key, Func<T, R> func)
			where R : class
		{
			modFactoryObjects[key] = o => func((T)o);
		}

		public void RegisterFactoryObject<T>(string key, Func<object, object> func)
		{
			if (!modFactoryObjects.ContainsKey(key))
			{
				modFactoryObjects.Add(key, func);
				return;
			}

			modFactoryObjects[key] = func;
		}

		public T GetObjectFromFactory<T>(string key) where T : class
		{
			if (!modFactoryObjects.ContainsKey(key))
				return default(T);

			return modFactoryObjects[key](null) as T;
		}

		public T GetObjectFromFactory<T>(string key, object obj) where T : class
		{
			if (!modFactoryObjects.ContainsKey(key))
				return default(T);

			return modFactoryObjects[key](obj) as T;
		}

		public object GetObjectFromFactory(string key)
		{
			if (!modFactoryObjects.ContainsKey(key))
				return default(object);

			return modFactoryObjects[key](null);
		}

		#endregion

		#region Protected Methods
		#endregion

		#region Properties
		#endregion




	}
}
