using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApi.Tests.Common.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace WebApi.Tests.Common.Bases
{
	public abstract class BaseUnitTestController
	{
		protected HttpClient modClient = new HttpClient();
		protected WebClientHelper modClientHelper = new WebClientHelper();
		protected WebClient modWebClient = new WebClient();
		protected string modBaseAddress;
		protected string modAddress;

		protected virtual void Initialize() { }
		protected void RunTest(Action action)
		{
			try
			{
				action();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		[TestCleanup()]
		public void Cleanup() 
		{
		}
	}
}
