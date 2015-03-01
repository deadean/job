using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApi.Web.Common.Implementations.Controllers;
using WebApi.Web.Common.Routing;
using WebApi.Common.Interfaces.Formatting.Json;
using WebApi.Common.Implementations.Formatting.Json;
using WebApi.Tests.Common.Bases;
using Newtonsoft.Json;
using System.IO;

namespace WebApi.Tests.Web.ApiService.Integration.LocalHost
{
	[TestClass]
	public class PhotosControllerTests : BaseLocalHostController
	{
		[TestMethod]
		public void PhotosControllerTests1()
		{
			//HttpResponseMessage response = this.modClient.GetAsync("api/v1/users/larkar/?Password=larkar3").Result;
			//Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
			//var responseString = response.Content.ReadAsStringAsync().Result;
			//var jsonResponse = JObject.Parse(responseString);
			//var userResponse = jsonResponse.ToObject<UserResponse>();
			//Assert.AreEqual(userResponse.PersonID, "1410291354071196084991");
		}

		[TestMethod]
		public void PhotosControllerTests2()
		{
			HttpResponseMessage response = this.modClient.GetAsync("api/v1/photos").Result;

			Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

			var responseString = response.Content.ReadAsStringAsync().Result;

			Assert.IsFalse(string.IsNullOrWhiteSpace(responseString));
		}
	}
}
