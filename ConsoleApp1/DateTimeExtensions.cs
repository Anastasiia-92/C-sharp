using System;

public static class DateTimeExtensions
{
	public static string CustomToString(this DateTime dateTime) =>
		$"{dateTime.Year}.{dateTime.Month}.{dateTime.Day}";
}
