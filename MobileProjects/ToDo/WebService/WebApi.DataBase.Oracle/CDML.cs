using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DataBase.Oracle.Interfaces.ModelService;

namespace WebApi.DataBase.Oracle
{
	public class CDML
	{
		IDataBaseService modDataBaseService;

		public CDML(IDataBaseService dataBaseService)
		{
			modDataBaseService = dataBaseService;
    }

		#region DML

		//public bool IsDoDML(string procedureName, CDBParameters parameters, CTransaction transaction)
		//{
		//	bool isResult = true;
		//	object result = null;
		//	if (!String.IsNullOrEmpty(procedureName) && parameters != null)
		//	{
		//		result = modDataBaseService.getScalar(procedureName, parameters, transaction);
		//		isResult = Convert.ToInt32(result) > 0;
		//	}
		//	return isResult;
		//}

		public object GetScalar(CDBQuery parameters, CTransaction transaction)
		{
			object result = null;
			if (!string.IsNullOrEmpty(parameters.ProcedureName))
			{
				result = modDataBaseService.getScalar(parameters, transaction);
			}
			return result;
		}
		#endregion DML		

		//#region Delete
		//public static bool DeleteObject(CObjectBase objectBase, CDBQuery pDelete)
		//{
		//	return DeleteObject(objectBase, pDelete.ProcedureName, pDelete.Parameters, null);
		//}

		//public static bool DeleteObject(CObjectBase objectBase, CDBQuery pDelete, CTransaction transaction)
		//{
		//	return DeleteObject(objectBase, pDelete.ProcedureName, pDelete.Parameters, transaction);
		//}

		//public static bool DeleteObject(CObjectBase objectBase, string procedureDelete, CDBParameters parametersDelete)
		//{
		//	return DeleteObject(objectBase, procedureDelete, parametersDelete, null);
		//}

		//public static bool DeleteObject(CObjectBase objectBase, string procedureDelete, CDBParameters parametersDelete, CTransaction transaction)
		//{
		//	bool isResult = false;
		//	if (objectBase != null)
		//	{
		//		if (objectBase.Status == enObjectStatus.Deleted)
		//		{
		//			isResult = IsDoDML(procedureDelete, parametersDelete, transaction);
		//			objectBase.Status = enObjectStatus.Normal;
		//		}
		//	}
		//	return isResult;
		//}
		//#endregion
	}
}
