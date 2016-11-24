using System;
using System.Collections.Generic;

namespace CountryPicker.Droid
{
	public static class LINQExtension
	{
		public static int FindIndexOf<T> (this IEnumerable<T> items, Func<T, bool> predicate)
		{
			int retVal = 0;
			foreach (var item in items) {
				if (predicate (item))
					return retVal;

				retVal++;
			}

			return -1;
		}
	}
}
