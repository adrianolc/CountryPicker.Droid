using Android.App;
using Android.Widget;
using Android.OS;
using CountryPicker.Droid.Widget;
using Android.Views;
using System;

namespace CountryPicker.Sample
{
	[Activity (Label = "CountryPicker.Sample", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity, AdapterView.IOnItemSelectedListener
	{
		CountrySpinner _spinner1;
		CountrySpinner _spinner2;


		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.Main);

			_spinner1 = FindViewById<CountrySpinner> (Resource.Id.spinner1);

			_spinner2 = FindViewById<CountrySpinner> (Resource.Id.spinner2);
			_spinner2.SetSelectedCountryForCode ("+55");

			_spinner2.OnItemSelectedListener = this;
		}

		public void OnItemSelected (AdapterView parent, View view, int position, long id)
		{
			var country = _spinner2.Adapter.GetItemAtPosition (position);
			_spinner1.SetSelectedCountryForIso (country.Iso);
		}

		public void OnNothingSelected (AdapterView parent)
		{
			
		}
	}
}
