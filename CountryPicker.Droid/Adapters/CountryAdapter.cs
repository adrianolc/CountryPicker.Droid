using System;
using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Widget;
using CountryPicker.Droid.Models;

namespace CountryPicker.Droid.Adapters
{
	public class CountryAdapter : BaseAdapter
	{
		readonly Context _context;
		readonly List<Country> _countries;

		public override int Count
		{
			get
			{
				return _countries.Count;
			}
		}

		public CountryAdapter (Context context, List<Country> countries)
		{
			_context = context;
			_countries = countries;
		}

		public int GetItemPosition (Func<Country, bool> predicate)
		{
			return _countries.FindIndexOf (predicate);
		}

		public Country GetItemAtPosition (int position)
		{
			return _countries[position];
		}

		public override Java.Lang.Object GetItem (int position)
		{
			return null;
		}

		public override long GetItemId (int position)
		{
			return position;
		}

		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			var country = _countries[position];

			View view = LayoutInflater.From (_context).Inflate (Resource.Layout.item_view, null, false);

			view.FindViewById<ImageView> (Resource.Id.country_flag).SetImageResource (country.FlagId);
			view.FindViewById<TextView> (Resource.Id.country_name).Text = country.Code;

			return view;
		}

		public override View GetDropDownView (int position, View convertView, ViewGroup parent)
		{
			var country = _countries[position];

			View view = LayoutInflater.From (_context).Inflate (Resource.Layout.item_drop_view, null, false);

			view.FindViewById<ImageView> (Resource.Id.country_flag).SetImageResource (country.FlagId);
			view.FindViewById<TextView> (Resource.Id.country_name).Text = country.Name;

			return view;
		}
	}
}
