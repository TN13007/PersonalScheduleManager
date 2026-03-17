using System;

public abstract class ScheduleItem
{
    private string _title = "";
    private string _description = "";
    private string _id;
    private Priority _priority;
    private Status _status;
    private DateTime _createdAt;

    public string Title
    {
        get { return _title; }
        set { _title = value; }
    }


    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }
    public string Id
    {
        get { return _id; }
    }
    public Status Status
    {
        get { return _status; }
        set { _status = value; }
    }

    public DateTime CreatedAt
    {
        get { return _createdAt; }
    }
    public Priority Priority
    {
        get { return _priority; }
        set { _priority = value; }
    }

    protected ScheduleItem()
    {
        _id = Guid.NewGuid().ToString();
        _createdAt = DateTime.Now;
        _status = Status.Planned;
        _priority = Priority.Normal;
    }

    public void MarkDone()
    {
        _status = Status.Done;
    }

    public void Cancel()
    {
        _status = Status.Canceled;
    }

    public abstract string GetTypeName();

    public abstract string Display();

    public abstract bool IsValid();

    public abstract bool Overlaps(ScheduleItem other);
}