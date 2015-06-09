using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using XLabs.Ioc;
using XLabs.Platform.Device;

namespace FeduciaTestTask.Droid
{
	[Activity(Label = "FeduciaTestTask", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);

			this.SetIoc();

			LoadApplication(new App());
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

