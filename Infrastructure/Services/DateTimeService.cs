using Application.Common.Interfaces;

namespace Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;

    public DateTimeRangeInfo CreateRange(DateTime start, DateTime end, DateTimeRangeType type)
    {
        start = start.Date;

        switch (type)
        {
            case DateTimeRangeType.Daily:
                end = start.AddDays(1).AddSeconds(-1);
                break;
            case DateTimeRangeType.Weekly:
                end = start.AddDays((int)start.DayOfWeek * -1).AddDays(8).AddSeconds(-1);
                break;
            case DateTimeRangeType.Monthly:
                break;
            case DateTimeRangeType.Range:
                end = end.Date.AddDays(1).AddSeconds(-1);
                break;
            default:
                throw new InvalidOperationException("Type is not valid");
        }

        return new DateTimeRangeInfo(start, end);
    }
}