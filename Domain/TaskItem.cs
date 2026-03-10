public class TaskItem : ScheduleItem
{
    private DateTime _deadline;
    private bool _isCompleted;

    public DateTime Deadline
    {
        get { return _deadline; }
        set { _deadline = value; }
    }

    public bool IsCompleted
    {
        get { return _isCompleted; }
        set { _isCompleted = value; }
    }

    public TaskItem()
    {
        _isCompleted = false;
    }

    public override string Display()
    {
        return $"[{GetTypeName()}] {Title} | Deadline: {Deadline:yyyy-MM-dd HH:mm} | Priority: {Priority} | Status: {Status}";
    }

    public override string GetTypeName()
    {
        return "Task";
    }

    public override bool IsValid()
    {
        return !string.IsNullOrWhiteSpace(Title)
            && Deadline != default
            && Enum.IsDefined(typeof(Priority), Priority)
            && Enum.IsDefined(typeof(Status), Status);
    }

    public override bool Overlaps(ScheduleItem other)
    {
        if (other == null)
        {
            return false;
        }

        if (other is TaskItem task)
        {
            return Deadline == task.Deadline;
        }

        if (other is ReminderItem reminder)
        {
            return Deadline == reminder.RemindTime;
        }

        if (other is EventItem ev && ev.TimeRange != null && ev.TimeRange.IsValid())
        {
            return Deadline >= ev.TimeRange.StartTime && Deadline < ev.TimeRange.EndTime;
        }

        return false;
    }

    public void MarkAsCompleted()
    {
        _isCompleted = true;
        Status = Status.Done;
    }
}