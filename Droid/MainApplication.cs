using System;

using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Plugin.CurrentActivity;

namespace WeatherApp.Droid
{

	[Application(Name = "com.weatherdvt.app.weatherappdvt.MainApplication")]
	public class MainApplication : Application, Application.IActivityLifecycleCallbacks
	{
		public MainApplication(IntPtr handle, JniHandleOwnership transer)
		  : base(handle, transer)
		{
		}

		public override void OnCreate()
		{
			base.OnCreate();
			RegisterActivityLifecycleCallbacks(this);

		}

		public override void OnTerminate()
		{
			base.OnTerminate();
			UnregisterActivityLifecycleCallbacks(this);
		}

		public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
		{
			CrossCurrentActivity.Current.Activity = activity;
		}

		public void OnActivityDestroyed(Activity activity)
		{
		}

		public void OnActivityPaused(Activity activity)
		{
		}

		public void OnActivityResumed(Activity activity)
		{
			CrossCurrentActivity.Current.Activity = activity;
		}

		public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
		{
		}

		public void OnActivityStarted(Activity activity)
		{
			CrossCurrentActivity.Current.Activity = activity;
		}

		public void OnActivityStopped(Activity activity)
		{
		}

		public static Typeface GetCustomTypeFace(string fontName)
		{
			Typeface typeFace = null;

			try
			{
				if (fontName != null && (fontName.Equals("WeatherThin") || fontName.Equals("Weather Thin")))
				{
					var typeface = Typeface.CreateFromAsset(Xamarin.Forms.Forms.Context.Assets, "Fonts/HelveticaNeue-Thin.otf");
					typeFace = typeface;
					return typeface;

				}
			}
			catch (Exception ex)
			{
			}
			return typeFace;
		}
	}
}