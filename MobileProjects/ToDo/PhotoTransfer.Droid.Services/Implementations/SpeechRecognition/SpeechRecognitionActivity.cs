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
using Xamarin.Forms;

namespace ToDo.Droid.Services.Implementations.SpeechRecognition
{
	[Activity(Label = "SpeechRecognitionActivity")]
	public class SpeechRecognitionActivity : Activity
	{
		private readonly int VOICE = 10;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			try
			{
				var voiceIntent = new Intent(RecognizerIntent.ActionRecognizeSpeech);
				voiceIntent.PutExtra(RecognizerIntent.ExtraLanguageModel, RecognizerIntent.LanguageModelFreeForm);

				voiceIntent.PutExtra(RecognizerIntent.ExtraPrompt
					, ToDo.Data.Constants.Constants.Messages.csMessageStartGoogleSpeechRecognitionIncomeMessage);

				voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputCompleteSilenceLengthMillis, 3000);
				voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputPossiblyCompleteSilenceLengthMillis, 3000);
				voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputMinimumLengthMillis, 30000);
				voiceIntent.PutExtra(RecognizerIntent.ExtraMaxResults, 1);

				// you can specify other languages recognised here, for example
				// voiceIntent.PutExtra(RecognizerIntent.ExtraLanguage, Java.Util.Locale.German);
				// if you wish it to recognise the default Locale language and German
				// if you do use another locale, regional dialects may not be recognised very well

				voiceIntent.PutExtra(RecognizerIntent.ExtraLanguage, Java.Util.Locale.Default);
				//voiceIntent.PutExtra(RecognizerIntent.ExtraLanguage, Java.Util.Locale.German);
				StartActivityForResult(voiceIntent, VOICE);
			}
			catch (Exception ex)
			{

			}
		}
		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			if (requestCode == VOICE)
			{
				if (resultCode == Result.Ok)
				{
					string textInput;
					var matches = data.GetStringArrayListExtra(RecognizerIntent.ExtraResults);
					if (matches.Count != 0)
					{
						textInput = matches[0];

						// limit the output to 500 characters
						if (textInput.Length > 500)
							textInput = textInput.Substring(0, 500);
					}
					else
						textInput = "No speech was recognised";

					try
					{
						MessagingCenter.Send<SpeechRecognitionActivity, string>(this
							, Constants.Constants.Messages.csMessageSpeechrecognitionResult, textInput);
					}
					catch { }
				}
			}

			base.OnActivityResult(requestCode, resultCode, data);
			Finish();
		}
	}
}