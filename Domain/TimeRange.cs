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
        return _startTime < _endTime;
    }

    public bool Overlaps(TimeRange other)
    {
        if (other == null || !IsValid() || !other.IsValid())
        {
            return false;
        }

        return _startTime < other.EndTime && other.StartTime < _endTime;
    }

    public TimeSpan GetDuration()
    {
        if (!IsValid())
        {
            return TimeSpan.Zero;
        }

        return _endTime - _startTime;
    }
}