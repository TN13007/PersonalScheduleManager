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
        throw new NotImplementedException();
    }

    public override string GetTypeName()
    {
        throw new NotImplementedException();
    }

    public override bool IsValid()
    {
        throw new NotImplementedException();
    }

    public override bool Overlaps(ScheduleItem other)
    {
        throw new NotImplementedException();
    }

    public void MarkAsCompleted()
    {
        throw new NotImplementedException();
    }
}