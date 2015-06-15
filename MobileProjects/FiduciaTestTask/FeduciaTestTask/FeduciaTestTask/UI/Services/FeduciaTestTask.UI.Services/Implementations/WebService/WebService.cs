using FeduciaTestTask.FeduciaTestTask.Data.Interfaces.Entities.Web;
using FeduciaTestTask.Services.Interfaces.WebService;
using FeduciaTestTask.UI.Data.Implementations.Entities.Web;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FeduciaTestTask.UI.Services.Implementations.WebService
{
	public class WebService : IWebService
	{

		#region Fields

		#endregion

		#region Properties

		#endregion

		#region Ctor

		#endregion

		#region Public Methods

		public async Task<IModifications> GetModificationsByCustomerCode(string customerCode)
		{
			HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(String.Format(Constants.Constants.WebService.csDefaultUrl + "{0}", customerCode));
			request.Method = "GET";

			TaskCompletionSource<int> tc = new TaskCompletionSource<int>();
			Modifications modifications = null;
			request.BeginGetResponse((ar) =>
			{
				var request1 = (HttpWebRequest)ar.AsyncState;
				using (var response = (HttpWebResponse)request1.EndGetResponse(ar))
				{
					var s = response.GetResponseStream();

					using (StreamReader sr = new StreamReader(s))
					{
						string strContent = sr.ReadToEnd();

						var jsonResponse = JObject.Parse(strContent);
						modifications = jsonResponse.ToObject<Modifications>();

						tc.SetResult(0);
					}
				}
			}
			, request);

			await tc.Task;
			
			return modifications;
		}

		#endregion

		#region Private Methods

		#endregion

		#region Protected Methods

		#endregion

	}
}
