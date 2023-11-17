    
namespace Application.Common.Interfaces;

public interface IDateTime
{
    DateTime Now { get; }

    DateTimeRangeInfo CreateRange(DateTime start, DateTime end, DateTimeRangeType type);
}
public enum DateTimeRangeType
{
    Daily, Weekly, Monthly, Range
}

public class DateTimeRangeInfo
{
    public DateTimeRangeInfo(DateTime start, DateTime end)
    {
        Start = start;
        End = end;
    }

    public DateTime Start { private set; get; }

    public DateTime End { private set; get; }
}