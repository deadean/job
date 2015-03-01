using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Speech;
using ToDo.UI.Common.Interfaces.SpeechRecognitionService;
using System.Threading.Tasks;
using ToDo.Data.Interfaces.SpeechRecognition;
using Xamarin.Forms;
using ToDo.Droid.Services.Implementations.SpeechRecognition;

[assembly: Dependency(typeof(Android_SpeechRecognitionService))]

namespace ToDo.Droid.Services.Implementations.SpeechRecognition
{
	public class Android_SpeechRecognitionService : ISpeechRecognitionService
	{
		public async Task<string> TryToRecognizeSpeech()
		{
			TaskCompletionSource<string> task = new TaskCompletionSource<string>();
			try
			{
				MessagingCenter.Subscribe<SpeechRecognitionActivity, string>(this
					, Constants.Constants.Messages.csMessageSpeechrecognitionResult
					, (sender, args) =>
				{
					task.SetResult(args);
				});

				Activity activity = (Activity)Forms.Context;
				var activity1 = new Intent(activity, typeof(SpeechRecognitionActivity));
				activity.StartActivity(activity1);
			}
			catch (Exception ex)
			{
				task.SetResult(string.Empty);
			}

			var res = await task.Task;
			task = null;
			MessagingCenter.Unsubscribe<SpeechRecognitionActivity, string>(this
				, Constants.Constants.Messages.csMessageSpeechrecognitionResult);
			return res;
		}

		public ISpeechRecognizer SpeechRecognizerInstance
		{
			get;
			private set;
		}
	}
}