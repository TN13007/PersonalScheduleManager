public class ScheduleValidator
{
    public bool ValidateItem(ScheduleItem item)
    {
        throw new NotImplementedException();
    }

    public bool CheckConflict(Schedule schedule, ScheduleItem newItem)
    {
        throw new NotImplementedException();
    }

    public bool ValidateTimeRange(TimeRange timeRange)
    {
        throw new NotImplementedException();
    }

    public bool ValidateTitle(string title)
    {
        throw new NotImplementedException();
    }

    public List<string> GetValidationErrors(ScheduleItem item)
    {
        throw new NotImplementedException();
    }
}