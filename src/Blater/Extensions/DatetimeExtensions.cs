using System;
using System.Globalization;

namespace Blater.Extensions;

public static class DatetimeExtensions
{
    public static string ToIso8601(this DateTime dateTime)
    {
        return dateTime.ToString("yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture);
    }

    public static DateTime SetKindToUtc(this DateTime data)
    {
        return DateTime.SpecifyKind(data, DateTimeKind.Utc);
    }
}