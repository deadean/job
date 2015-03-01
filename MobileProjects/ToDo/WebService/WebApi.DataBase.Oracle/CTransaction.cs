using System;
using System.Threading;
using WebApi.Common.Implementations.Logging;
using WebApi.DataBase.Oracle.Implementations.Unity;
using WebApi.DataBase.Oracle.Interfaces.ModelService;

namespace WebApi.DataBase.Oracle
{
	public class CTransaction : IDisposable
	{
		private static IDataBaseService modLazyDataBase
		{ 
			get
			{
				return Container.Resolve<IDataBaseService>();
			}
		}

		#region Properties

		public string ID { get; set; }

		public bool IsOpenTransaction { get; set; }

		#endregion

		#region Public Methods

		public static bool Execute(Func<CTransaction, bool> actionToExecuteWithTransaction)
		{
			return Execute(actionToExecuteWithTransaction, _ => { }, false);
		}

		public static bool Execute(Func<CTransaction, bool> actionToExecuteWithTransaction, Action<CTransaction> onTransactionException, bool isNeedRethrow)
		{
			return Execute(actionToExecuteWithTransaction, () => { }, onTransactionException, isNeedRethrow);
		}

		public static bool Execute(Func<CTransaction, bool> actionToExecuteWithTransaction, Action onMaxTransactionsReached, Action<CTransaction> onDatabaseException, bool isNeedRethrow)
		{
			if (actionToExecuteWithTransaction == null || onMaxTransactionsReached == null || onDatabaseException == null)
				return false;

			var result = false;

			using (var transaction = new CTransaction())
			{
				try
				{
					if (transaction.OpenTransaction())
					{
						var isExecuted = actionToExecuteWithTransaction(transaction);

						if (transaction.IsOpenTransaction)
						{
							transaction.CloseTransaction(isExecuted);
						}

						result = isExecuted;
					}
					else
					{
						onMaxTransactionsReached();
					}
				}
				catch (CDataBaseException exc)
				{
					CLog.Log(LogType.ERR, string.Format("OnTransactionException => {0}", exc.Message));

					onDatabaseException(transaction);

					if (isNeedRethrow) throw;
				}
				catch (ThreadAbortException) { }
				catch (Exception exc)
				{
					CLog.Log("Execute(Func<CTransaction, bool> actionToExecuteWithTransaction, Action onMaxTransactionsReached, Action<CTransaction> onDatabaseException, bool isNeedRethrow)", exc);

					if (isNeedRethrow) throw;
				}
			}

			return result;
		}
		
		public void CloseTransaction(bool isSaveOk)
		{
			try
			{
				if (IsOpenTransaction)
				{
					if (modLazyDataBase.IsTraceNeedOn)
					{
						modLazyDataBase.SetDatabaseTraceAction(false, this);
					}

					if (isSaveOk)
					{
						modLazyDataBase.CommitTransaction(ID);
					}
					else
					{
						modLazyDataBase.RollbackTransaction(ID);
					}

					IsOpenTransaction = false;
				}
			}
			catch (ThreadAbortException) { }
			catch (CDataBaseException) { throw; }
			catch (Exception exc)
			{
				CLog.Log("CloseTransaction(bool isSaveOk)", exc);
			}
		}

		public void Commit()
		{
			CloseTransaction(true);
		}

		public bool OpenTransaction()
		{
			if (IsOpenTransaction)
				return true;

			ID = modLazyDataBase.OpenTransaction2();

			if (string.IsNullOrEmpty(ID))
				return false;

			IsOpenTransaction = true;

			if (modLazyDataBase.IsTraceNeedOn)
			{
				modLazyDataBase.SetDatabaseTraceAction(true, this);
			}

			return IsOpenTransaction;
		}

		public void Rollback()
		{
			CloseTransaction(false);
		}

		#endregion

		#region IDisposable Members

		public void Dispose()
		{
			if (IsOpenTransaction)
			{
				Rollback();
			}
		}

		#endregion
	}
}