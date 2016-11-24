using System;
using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.Content.Res;
using CountryPicker.Droid.Models;
using Java.Util;
using LibPhoneNumber.Droid;

namespace CountryPicker.Droid.Util
{
	public class CountryUtil
	{
		readonly PhoneNumberUtil _phoneUtil;
		readonly Resources _resources;
		readonly string _packageName;

		public CountryUtil (Context context)
		{
			_phoneUtil = PhoneNumberUtil.CreateInstance (context);
			_resources = context.Resources;
			_packageName = context.PackageName;
		}

		public List<Country> AvailableCountries
		{
			get { 
				return GetAvailableCountries ().Distinct (new DistinctItemComparer())
					                           .OrderBy (c => c.Name).ToList (); 
			}
		}

		IEnumerable<Country> GetAvailableCountries ()
		{
			foreach (var locale in Locale.GetAvailableLocales ()) {
				if (string.IsNullOrEmpty (locale.Country) || string.IsNullOrWhiteSpace (locale.DisplayCountry))
					continue;

				var drawable = GetCountryFlag (locale.Country);

				if (drawable <= 0)
					continue;

				yield return new Country {
					Iso = locale.Country,
					Name = locale.DisplayCountry,
					Code = string.Format ("+{0}", _phoneUtil.GetCountryCodeForRegion (locale.Country)),
					FlagId = drawable
				};
			}
		}

		int GetCountryFlag (string iso)
		{
			string drawable = string.Format ("{0}_flag", iso.ToLower ());
			return _resources.GetIdentifier (drawable, "mipmap", _packageName);
		}

		internal class DistinctItemComparer : IEqualityComparer<Country>
		{
			public bool Equals (Country x, Country y)
			{
				return x.Name.Equals (y.Name);
			}

			public int GetHashCode (Country obj)
			{
				return obj.Name.GetHashCode ();
			}
		}
	}
}
