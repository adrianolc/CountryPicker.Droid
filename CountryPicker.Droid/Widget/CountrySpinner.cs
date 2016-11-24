using System.Collections.Generic;
using Android.Content;
using Android.Util;
using Android.Widget;
using CountryPicker.Droid.Adapters;
using CountryPicker.Droid.Models;

namespace CountryPicker.Droid.Widget
{
	public class CountrySpinner : Spinner
	{
		public new CountryAdapter Adapter 
		{ 
			set {
				base.Adapter = value;
			}
			get {
				return base.Adapter as CountryAdapter;
			}

		}

		public CountrySpinner (Context context)
			: this (context, null)
		{

		}

		public CountrySpinner (Context context, IAttributeSet attrs)
			: base (context, attrs)
		{
			InitWithAdapter ();
		}

		void InitWithAdapter ()
		{
			List<Country> countries = new Util.CountryUtil (Context).AvailableCountries;

			Adapter = new CountryAdapter (Context, countries);
		}

		public void SetSelectedCountryForIso (string contryIso, bool animanted = false)
		{
			int position = Adapter.GetItemPosition (c => c.Iso.Equals (contryIso));

			if (position > -1)
				SetSelection (position, animanted);
		}

		public void SetSelectedCountryForCode (string contryCode, bool animanted = false)
		{
			int position = Adapter.GetItemPosition (c => c.Code.Equals (contryCode));

			if (position > -1)
				SetSelection (position, animanted);
		}
	}
}
