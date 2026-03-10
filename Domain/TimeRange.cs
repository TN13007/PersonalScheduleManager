public class TimeRange
{
    private DateTime _startTime;
    private DateTime _endTime;

    public DateTime StartTime
    {
        get { return _startTime; }
        set { _startTime = value; }
    }

    public DateTime EndTime
    {
        get { return _endTime; }
        set { _endTime = value; }
    }

    public TimeRange(DateTime startTime, DateTime endTime)
    {
        _startTime = startTime;
        _endTime = endTime;
    }

    public bool IsValid()
    {
        throw new NotImplementedException();
    }

    public bool Overlaps(TimeRange other)
    {
        throw new NotImplementedException();
    }

    public TimeSpan GetDuration()
    {
        throw new NotImplementedException();
    }
}