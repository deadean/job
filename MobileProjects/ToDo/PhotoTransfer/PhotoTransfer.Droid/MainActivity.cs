using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms.Labs;
using Xamarin.Forms.Labs.Mvvm;
using Xamarin.Forms.Labs.Services;
using Xamarin.Forms.Labs.Droid;
using Android.Content;
using Xamarin.Forms;

namespace ToDo.Droid
{
	[Activity(Label = "ToDo", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			this.SetIoc();
			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);
			LoadApplication(new App());

			AppDomain currentDomain = AppDomain.CurrentDomain;
			currentDomain.UnhandledException += new UnhandledExceptionEventHandler(HandleExceptions);

			AndroidEnvironment.UnhandledExceptionRaiser += AndroidEnvironment_UnhandledExceptionRaiser;

		}

		void AndroidEnvironment_UnhandledExceptionRaiser(object sender, RaiseThrowableEventArgs e)
		{
			e.Handled = true;
		}

		private void HandleExceptions(object sender, UnhandledExceptionEventArgs e)
		{
			var exc = (e.ExceptionObject as Exception).Message;
		}

		private void SetIoc()
		{
			var resolverContainer = new SimpleContainer();

			resolverContainer.Register<IDevice>(t => AndroidDevice.CurrentDevice)
					.Register<IDisplay>(t => t.Resolve<IDevice>().Display)
					.Register<IDependencyContainer>(resolverContainer);

			Resolver.SetResolver(resolverContainer.GetResolver());
		}
	}
}

