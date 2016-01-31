
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace DroidPop
{
	/// <summary>
	/// Web pop fragment.
	/// http://bit.ly/droid_dialog
	/// </summary>
	public class WebPopFragment : DialogFragment, View.IOnTouchListener
	{
		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your fragment here
		}


		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			// Use this to return your custom view for this Fragment
			// return inflater.Inflate(Resource.Layout.YourFragment, container, false);

			base.OnCreateView (inflater, container, savedInstanceState);

			var view = inflater.Inflate(Resource.Layout.WebPop, container, false);

			view.Button (Resource.Id.CloseButton).Click += delegate
			{
				this.Dismiss();
			};
			var webview = view.WebView (Resource.Id.WebContent);
			webview.LoadData (@"<html><body><a href=""#close"">Close</a></body></html>",
				"text/html", "utf-u");
			webview.SetOnTouchListener (this);
//			webview.Click += (object sender, EventArgs e) => {
//				Android.Util.Log.Debug("WebPopFragment", "Web View Clicked");
//			};
			return view;
		
		}

		public bool OnTouch(View v, MotionEvent e)
		{
			Android.Util.Log.Debug ("WebPopFragment", "OnTouch {0}", e.Action.ToString ());
			return true;
		}
			
	}

}

