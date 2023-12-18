using System;

public class DateTimeHelper
{

	public static string CustomToString(DateTime dateTime) =>
		$"{dateTime.Year}.{dateTime.Month}.{dateTime.Day}";
}
