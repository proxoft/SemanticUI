namespace Proxoft.FomanticUI.Core;

/// <summary>
///     What a calendar selects; also the deepest view the calendar drills down to.
/// </summary>
public enum CalendarType
{
    Date,
    Month,
    Year
}

/// <summary>
///     The page a calendar currently shows.
/// </summary>
public enum CalendarView
{
    Day,
    Month,
    Year
}

public static class CalendarTypeExtensions
{
    public static CalendarView ToView(this CalendarType type)
    {
        return type switch
        {
            CalendarType.Month => CalendarView.Month,
            CalendarType.Year => CalendarView.Year,
            _ => CalendarView.Day
        };
    }

    /// <summary>
    ///     Truncates the date to the type's precision: first day of the month, or January 1st of the year.
    /// </summary>
    public static DateOnly Normalize(this CalendarType type, DateOnly date)
    {
        return type switch
        {
            CalendarType.Month => new DateOnly(date.Year, date.Month, 1),
            CalendarType.Year => new DateOnly(date.Year, 1, 1),
            _ => date
        };
    }
}