using ToDo.Data;
using ToDo.Data.Constants;
using ToDo.UI.Data.Bases.Entities;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoTransfer.Data.Interfaces.Entities;

namespace ToDo.UI.Data.Implementations.Entities
{
	public class ToDoItem:AbstractEntityBase, IToDo
	{

		#region Fields
		
		public string Name { get; set; }

		[PrimaryKey]
		public string ID { get; set; }

		#endregion

		#region Properties

		#endregion

		#region Ctor

		public ToDoItem()
		{
			ID = KeyGenerator.GetKey(ClassType);
		}

		#endregion

		#region Public Methods

		#endregion

		#region Private Methods

		#endregion

		#region Protected Methods

		protected override void GenerateId()
		{
			this.GenerateIdAndClassType(Constants.Entitites.csToDo);
		}

		protected override string PrivateGetEntityId()
		{
			return this.ID;
		}

		#endregion


	}
}
