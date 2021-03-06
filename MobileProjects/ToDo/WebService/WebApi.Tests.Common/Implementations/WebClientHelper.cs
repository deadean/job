﻿// WebClientHelper.cs
// Copyright Jamie Kurtz, Brian Wortman 2014.

using System;
using System.Net;
using System.Text;
using WebApi.Common.Implementations.Constants;

namespace WebApi.Tests.Common.Implementations
{
	public class WebClientHelper
	{
		public WebClient CreateWebClient(string username = "bhogg"
			, string contentType = Constants.MediaTypeNames.TextJson
			, string JWT = ""
			)
		{
			var webClient = new WebClient();

			if (string.IsNullOrWhiteSpace(JWT))
			{
				var creds = username + ":" + "ignored";
				var bcreds = Encoding.ASCII.GetBytes(creds);
				var base64Creds = Convert.ToBase64String(bcreds);
				webClient.Headers.Add("Authorization", "Basic " + base64Creds);
			}
			else
			{
				webClient.Headers.Add("Authorization", "Bearer " + JWT);
			}

			webClient.Headers.Add("Content-Type", contentType);
			return webClient;
		}
	}
}