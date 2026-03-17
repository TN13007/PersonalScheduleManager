public class ScheduleValidator
{
    public bool ValidateItem(ScheduleItem item)
    {
        return item != null && item.IsValid();
    }

    public bool CheckConflict(Schedule schedule, ScheduleItem newItem)
    {
        List<ScheduleItem> items = schedule.Items;
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].Id != newItem.Id && items[i].Overlaps(newItem))
            {
                return true;
            }
        }
        return false;
    }

    public bool ValidateTimeRange(TimeRange timeRange)
    {
        return timeRange != null && timeRange.IsValid();
    }

    public bool ValidateTitle(string title)
    {
        return !string.IsNullOrWhiteSpace(title);
    }

    public List<string> GetValidationErrors(ScheduleItem item)
    {
        List<string> errors = new List<string>();

        if (item == null)
        {
            errors.Add("Item cannot be null.");
            return errors;
        }

        if (string.IsNullOrWhiteSpace(item.Title))
            errors.Add("Title is required.");

        if (item is TaskItem task)
        {
            if (task.Deadline == default)
                errors.Add("Deadline is required for Task.");
        }
        else if (item is EventItem ev)
        {
            if (ev.TimeRange == null || !ev.TimeRange.IsValid())
                errors.Add("A valid time range is required for Event.");
            if (string.IsNullOrWhiteSpace(ev.Location))
                errors.Add("Location is required for Event.");
        }
        else if (item is ReminderItem reminder)
        {
            if (reminder.RemindTime == default)
                errors.Add("Remind time is required for Reminder.");
        }

        return errors;
    }
}