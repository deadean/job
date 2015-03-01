namespace WebApi.DataBase.Oracle.Implementations.ModelService.DataBaseQueries.User
{
	internal static class UserDataBaseQueries
	{
		public static CDBQuery sqlAuthorizeUser(string userLogin, string userPassword)
		{
			CDBQuery parameters = new CDBQuery("AD_ACC.USER_FIND");
			parameters.Add("p_real_user_acc_norm", userLogin);
			parameters.Add("p_ad_user_pwd", userPassword);
			return parameters;
		}

		public static CDBQuery sqlPersonEmploymentsSelect(string personId, string realUserId)
		{
			CDBQuery parameters = new CDBQuery("ad_crm.person_employments_select");
			parameters.Add("p_person_id", personId);
			parameters.Add("p_real_user_id", realUserId);
			return parameters;
		}
	}
}
