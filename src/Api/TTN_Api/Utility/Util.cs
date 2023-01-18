using System;

public static class Extensions
{
    public static DateTime ToCentralTime(this DateTime value)
    {
        //Central Europe Standard Time
        //return TimeZoneInfo.ConvertTime(value, TimeZoneInfo.FindSystemTimeZoneById("W. Central Africa Standard Time"));
        return TimeZoneInfo.ConvertTime(value, TimeZoneInfo.FindSystemTimeZoneById("Central Europe Standard Time"));
    }
}