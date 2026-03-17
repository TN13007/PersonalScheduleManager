public class Schedule
{
    private string _id;
    private string _name = "";
    private List<ScheduleItem> _items;
    private DateTime _createdAt;
    private DateTime _updatedAt;

    public string Id
    {
        get { return _id; }
        set { _id = value; }
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public List<ScheduleItem> Items
    {
        get { return _items; }
        set { _items = value; }
    }

    public DateTime CreatedAt
    {
        get { return _createdAt; }
        set { _createdAt = value; }
    }

    public DateTime UpdatedAt
    {
        get { return _updatedAt; }
        set { _updatedAt = value; }
    }

    public Schedule()
    {
        _id = Guid.NewGuid().ToString();
        _items = new List<ScheduleItem>();
        _createdAt = DateTime.Now;
        _updatedAt = DateTime.Now;
    }

    public void AddItem(ScheduleItem item)
    {
        throw new NotImplementedException();
    }

    public void RemoveItem(string itemId)
    {
        throw new NotImplementedException();
    }

    public ScheduleItem GetItemById(string itemId)
    {
        throw new NotImplementedException();
    }

    public List<ScheduleItem> GetItemsByDate(DateTime date)
    {
        throw new NotImplementedException();
    }

    public List<ScheduleItem> GetItemsByPriority(Priority priority)
    {
        throw new NotImplementedException();
    }

    public List<ScheduleItem> SearchItems(string keyword)
    {
        throw new NotImplementedException();
    }

    public void UpdateItem(ScheduleItem item)
    {
        throw new NotImplementedException();
    }

    public void ClearCompleted()
    {
        throw new NotImplementedException();
    }
}