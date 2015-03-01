using ToDo.UI.DataBases.Implementations.InternalStorage;
using SQLite.Net.Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.UI.DataBases.Interfaces.DataBases
{
	public interface ISQLiteConnection
	{
		ConnectionInfo<SQLiteAsyncConnection> GetConnection();
	}
}
