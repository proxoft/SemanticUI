using System.Globalization;

namespace Proxoft.FomanticUI.Core;

public sealed record CalendarCell(string Text, DateOnly Date, bool IsSelectable, string Class);

public sealed record CalendarOptions(
    DateOnly Today,
    DateOnly? Selected = null,
    DateOnly? MinDate = null,
    DateOnly? MaxDate = null,
    Func<DateOnly, bool>? IsDisabledDate = null,
    DayOfWeek FirstDayOfWeek = DayOfWeek.Sunday,
    CultureInfo? Culture = null);

/// <summary>
///     One page of a calendar (a month of days, a year of months or twelve years), computed the same way
///     as Fomantic UI's calendar module so the result matches its CSS.
/// </summary>
public sealed class CalendarPage
{
    private CalendarPage(
        CalendarView view,
        string header,
        DateOnly? previous,
        DateOnly? next,
        IReadOnlyList<string> columnHeaders,
        IReadOnlyList<IReadOnlyList<CalendarCell>> rows)
    {
        View = view;
        Header = header;
        Previous = previous;
        Next = next;
        ColumnHeaders = columnHeaders;
        Rows = rows;
    }

    public CalendarView View { get; }

    public string Header { get; }

    /// <summary>
    ///     Focus date of the previous page, or null when the previous page is entirely out of range.
    /// </summary>
    public DateOnly? Previous { get; }

    /// <summary>
    ///     Focus date of the next page, or null when the next page is entirely out of range.
    /// </summary>
    public DateOnly? Next { get; }

    /// <summary>
    ///     Day names for the day view; empty for month and year views.
    /// </summary>
    public IReadOnlyList<string> ColumnHeaders { get; }

    public IReadOnlyList<IReadOnlyList<CalendarCell>> Rows { get; }

    public int Columns => View == CalendarView.Day ? 7 : 3;

    public string TableClass(bool inverted)
    {
        var columns = View == CalendarView.Day ? "seven" : "three";
        return new[]
        {
            "ui celled center aligned unstackable table",
            View.ToString().ToLower(),
            $"{columns} column",
            "inverted".ToClassIf(inverted)
        }.ToClass();
    }

    public static CalendarPage Create(CalendarView view, DateOnly focus, CalendarOptions options)
    {
        return view switch
        {
            CalendarView.Year => CreateYearPage(focus, options),
            CalendarView.Month => CreateMonthPage(focus, options),
            _ => CreateDayPage(focus, options)
        };
    }

    private static CalendarPage CreateDayPage(DateOnly focus, CalendarOptions options)
    {
        CultureInfo culture = options.Culture ?? CultureInfo.CurrentCulture;
        DateOnly first = new(focus.Year, focus.Month, 1);
        DateOnly last = LastDayOfMonth(first);
        var firstColumn = ((int)first.DayOfWeek - (int)options.FirstDayOfWeek + 7) % 7;

        var columnHeaders = Enumerable.Range(0, 7)
            .Select(i => culture.DateTimeFormat.ShortestDayNames[((int)options.FirstDayOfWeek + i) % 7])
            .ToArray();

        // constant height: always 6 rows, as Fomantic's default constantHeight setting does
        var rows = Enumerable.Range(0, 6)
            .Select(r => (IReadOnlyList<CalendarCell>)Enumerable.Range(0, 7)
                .Select(c => TryAddDays(first, r * 7 + c - firstColumn))
                .Select(date => DayCell(date, first.Month, options))
                .ToArray())
            .ToArray();

        return new CalendarPage(
            CalendarView.Day,
            first.ToString(culture.DateTimeFormat.YearMonthPattern, culture),
            first > DateOnly.MinValue && IsInRange(DateOnly.MinValue, first.AddDays(-1), options) ? first.AddMonths(-1) : null,
            last < DateOnly.MaxValue && IsInRange(last.AddDays(1), DateOnly.MaxValue, options) ? first.AddMonths(1) : null,
            columnHeaders,
            rows);
    }

    private static CalendarPage CreateMonthPage(DateOnly focus, CalendarOptions options)
    {
        CultureInfo culture = options.Culture ?? CultureInfo.CurrentCulture;
        var year = focus.Year;

        var rows = Enumerable.Range(0, 4)
            .Select(r => (IReadOnlyList<CalendarCell>)Enumerable.Range(1 + r * 3, 3)
                .Select(month =>
                {
                    DateOnly date = new(year, month, 1);
                    var selectable = IsInRange(date, LastDayOfMonth(date), options);
                    var text = culture.DateTimeFormat.AbbreviatedMonthNames[month - 1];
                    return Cell(text, date, selectable, false,
                        options.Selected is { } s && s.Year == year && s.Month == month,
                        options.Today.Year == year && options.Today.Month == month);
                })
                .ToArray())
            .ToArray();

        return new CalendarPage(
            CalendarView.Month,
            year.ToString(culture),
            year > 1 && IsInRange(DateOnly.MinValue, new DateOnly(year - 1, 12, 31), options) ? focus.AddYears(-1) : null,
            year < 9999 && IsInRange(new DateOnly(year + 1, 1, 1), DateOnly.MaxValue, options) ? focus.AddYears(1) : null,
            [],
            rows);
    }

    private static CalendarPage CreateYearPage(DateOnly focus, CalendarOptions options)
    {
        CultureInfo culture = options.Culture ?? CultureInfo.CurrentCulture;

        // Fomantic shows 12 years: the decade ending at the next multiple of ten, plus two more
        var decadeYear = (int)Math.Ceiling(focus.Year / 10.0) * 10;
        var start = decadeYear - 9;

        var rows = Enumerable.Range(0, 4)
            .Select(r => (IReadOnlyList<CalendarCell>)Enumerable.Range(start + r * 3, 3)
                .Select(year =>
                {
                    if (year > 9999) return new CalendarCell("", DateOnly.MaxValue, false, "link disabled");

                    DateOnly date = new(year, 1, 1);
                    var selectable = IsInRange(date, new DateOnly(year, 12, 31), options);
                    return Cell(year.ToString(culture), date, selectable, false,
                        options.Selected?.Year == year,
                        options.Today.Year == year);
                })
                .ToArray())
            .ToArray();

        return new CalendarPage(
            CalendarView.Year,
            $"{start} - {decadeYear + 2}",
            start > 10 && IsInRange(DateOnly.MinValue, new DateOnly(start - 1, 12, 31), options) ? focus.AddYears(-10) : null,
            decadeYear + 1 <= 9999 && IsInRange(new DateOnly(decadeYear + 1, 1, 1), DateOnly.MaxValue, options) ? new DateOnly(decadeYear + 1, 1, 1) : null,
            [],
            rows);
    }

    private static CalendarCell DayCell(DateOnly? date, int month, CalendarOptions options)
    {
        if (date is not { } d)
            // outside the DateOnly range
            return new CalendarCell("", DateOnly.MinValue, false, "link adjacent disabled");

        // days of adjacent months are shown but not selectable (Fomantic's selectAdjacentDays: false)
        var adjacent = d.Month != month;
        var selectable = !adjacent
                         && IsInRange(d, d, options)
                         && !(options.IsDisabledDate?.Invoke(d) ?? false);

        return Cell(d.Day.ToString(options.Culture ?? CultureInfo.CurrentCulture), d, selectable, adjacent,
            !adjacent && options.Selected == d,
            !adjacent && options.Today == d);
    }

    private static CalendarCell Cell(string text, DateOnly date, bool selectable, bool adjacent, bool active, bool today)
    {
        var @class = new[]
        {
            "link",
            "adjacent".ToClassIf(adjacent),
            "disabled".ToClassIf(!selectable),
            "active".ToClassIf(active),
            "today".ToClassIf(today)
        }.ToClass();

        return new CalendarCell(text, date, selectable, @class);
    }

    /// <summary>
    ///     true when the period [from, to] overlaps [MinDate, MaxDate].
    /// </summary>
    private static bool IsInRange(DateOnly from, DateOnly to, CalendarOptions options)
    {
        return (options.MinDate is not { } min || to >= min)
               && (options.MaxDate is not { } max || from <= max);
    }

    private static DateOnly LastDayOfMonth(DateOnly date)
    {
        return new DateOnly(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
    }

    private static DateOnly? TryAddDays(DateOnly date, int days)
    {
        var dayNumber = date.DayNumber + days;
        return dayNumber < DateOnly.MinValue.DayNumber || dayNumber > DateOnly.MaxValue.DayNumber
            ? null
            : DateOnly.FromDayNumber(dayNumber);
    }
}