
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
	public class WebPopFragment : DialogFragment
	{
		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your fragment here
		}
			
		MyWebViewClient WebClient {get;set ; } = new MyWebViewClient ();

		public override View OnCreateView (
			LayoutInflater inflater, 
			ViewGroup container, 
			Bundle savedInstanceState
		)
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
			webview.LoadData (
				@"<html><body><a href=""/close"">Close</a></body></html>",
				"text/html", "utf-u");
			
			webview.SetWebViewClient (WebClient);
			WebClient.OnNavigating += (object sender, string url) => {
				if(url.IndexOf("close") >= 0 ){
					Dismiss();
				}
			};

			return view;
		
		}

			
	}

	public class MyWebViewClient : Android.Webkit.WebViewClient
	{
		public delegate void OnNavigatingEvent(object sender, string url);
		public event OnNavigatingEvent OnNavigating;

		public override bool ShouldOverrideUrlLoading (
			Android.Webkit.WebView view, 
			string url
		)
		{
			Android.Util.Log.Debug (
				"MyWebViewClinet", "ShouldOverrideUrlLoading {0}", url);
		
			//	var res =  base.ShouldOverrideUrlLoading (view, url);
			/// view.LoadUrl (url);
		
			if (OnNavigating != null) {
				OnNavigating (view, url);
			}
			return false;
		}
	}

}

