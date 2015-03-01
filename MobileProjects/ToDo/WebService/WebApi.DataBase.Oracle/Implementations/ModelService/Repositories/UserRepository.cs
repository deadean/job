using System;
using System.Data.Common;
using WebApi.Common.Implementations.Converters;
using WebApi.Data.Implementations.Entities;
using WebApi.Data.Interfaces.Entities;
using WebApi.DataBase.Oracle.Bases.ModelService.Repositories;
using WebApi.DataBase.Oracle.Implementations.ModelService.DataBaseQueries.User;
using WebApi.DataBase.Oracle.Interfaces.ModelService.Repositories;

namespace WebApi.DataBase.Oracle.Implementations.ModelService.Repositories
{
	internal sealed class UserRepository : RepositoryBase, IUserRepository
	{
		#region Fields

		#endregion

		#region Ctor
		#endregion

		#region Private Methods

		private string EncryptToMD5(string password)
		{
			string result = String.Empty;
			try
			{
				System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
				byte[] bs = System.Text.Encoding.UTF8.GetBytes(password);
				bs = x.ComputeHash(bs);
				System.Text.StringBuilder s = new System.Text.StringBuilder();
				foreach (byte b in bs)
				{
					s.Append(b.ToString("x2").ToLower());
				}
				result = s.ToString().ToUpper();
			}
			catch (Exception exc)
			{
				modLog.Debug("EncryptToMD5", exc);
			}

			return result;
		}

		private User GetUser(string login, string password)
		{
			password = this.EncryptToMD5(password);
			User user = null;
			CDBQuery dbQuery = UserDataBaseQueries.sqlAuthorizeUser(login, password);
			using (DbDataReader reader = modDataBase.getReader(dbQuery))
			{
				if (reader != null && reader.HasRows(dbQuery))
				{
					if (reader.Read())
					{
						user = new User();
						user.ID = DbReaderConvert.ToString(reader, 0);
						user.PersonID = DbReaderConvert.ToString(reader, 12);
						user.PreName = DbReaderConvert.ToString(reader, 21);
						user.PostName = DbReaderConvert.ToString(reader, 22);
					}
				}
			}
			return user;
		}

		#endregion

		#region Public Methods

		public IPersonInformation GetUserByLoginAndPassword(string login, string password)
		{
			IUser user = null;

			if (string.IsNullOrWhiteSpace(password))
				return null;

			try
			{
				user = GetUser(login, password);

			}
			catch (Exception exc)
			{
				user = null;
				modLog.Debug("GetUserByLoginAndPassword", exc);
			}

			return user;
		}

		#endregion

		#region Protected Methods

		public override void InitLog()
		{
			modLog = this.GetLog<UserRepository>();
		}

		#endregion

		#region Properties
		#endregion

	}
}
