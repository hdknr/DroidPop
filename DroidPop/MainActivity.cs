using Android.App;
using Android.Widget;
using Android.OS;

namespace DroidPop
{
	[Activity (Label = "DroidPop", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += delegate {
				button.Text = string.Format ("{0} clicks!", count++);
			};

			this.Button(Resource.Id.OpenWebPop).Click += OpenWebPopDialog;

		}

		void OpenWebPopDialog (object sender, System.EventArgs e)
		{
			var transaction = FragmentManager.BeginTransaction();
			var dialogFragment = new WebPopFragment();
			dialogFragment.Show(transaction, "webpop_fragment");
		}
	}
}


