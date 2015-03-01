using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.DataBase.Oracle.Interfaces.Factories
{
	public interface IDataObjectsFactory
	{
		T GetObjectFromFactory<T>(string key) where T : class;
		T GetObjectFromFactory<T>(string key, object obj) where T : class;
		object GetObjectFromFactory(string key);

		void RegisterFactoryObject<T>(string key) where T : new();
		void RegisterFactoryObject<T>(string key, Func<object> func);
		void RegisterFactoryObject<T>(string key, Func<object, object> func);
		void RegisterFactoryObject<T, R>(string key, Func<T, R> func)
			where R : class;
	}
}
