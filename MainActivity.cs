using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Kevin.Core;

namespace Kevin.Android
{
	[Activity (Label = "Kevin for Android", MainLauncher = true)]
	public class MainActivity : Activity, Output
	{
		KevinCore core;

		TextView output;

		protected override void OnCreate (Bundle bundle)
		{

			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			core = new KevinCore (this);
			// Get our button from the layout resource,
			// and attach an event to it

			EditText input = FindViewById<EditText> (Resource.Id.input);
			output = FindViewById<TextView> (Resource.Id.textView1);
			input.KeyPress += (object sender, View.KeyEventArgs e) => {
				e.Handled = false;
				if (e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter) {
					e.Handled = true;
					output.Append ("you: " + input.Text + "\n");
					core.tell(input.Text);
					input.Text = "";
				}
			};
		}

		#region Output implementation

		public void send (string hey)
		{
			output.Append ("Kevin: " + hey + "\n");
		}

		#endregion
	}
}


