using WebApi.Data.Entities.Bases;
using WebApi.Data.Interfaces.Entities;

namespace WebApi.Data.Implementations.Entities
{
	public class User : EntityBase, IUser
	{
		public string PersonID { get; set; }
		public string PreName { get; set; }
		public string PostName { get; set; }
		public string Function { get; set; }
	}
}
