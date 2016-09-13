using System;

namespace Crawler.UnitTests.Extensions
{
	public static class StringExt
	{
		public static bool IsValidUrl(this string url)
		{
			if (string.IsNullOrEmpty(url))
				return false;

			Uri uriResult;
			return Uri.TryCreate(url, UriKind.Absolute, out uriResult);
		}
	}
}
