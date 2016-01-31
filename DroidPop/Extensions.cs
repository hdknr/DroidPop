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
	public static class Extensions
	{

		public static Button Button(this View view , int id ){
			return view.FindViewById<Button> (id);
		}

		public static Button Button(this Activity activity , int id ){
			return activity.FindViewById<Button> (id);
		}
	}
}

