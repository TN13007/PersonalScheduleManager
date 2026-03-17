public class Schedule
{
    private string _id;
    private string _name = string.Empty;
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
        _items.Add(item);
        _updatedAt = DateTime.Now;
    }

    public void RemoveItem(string itemId)
    {
        ScheduleItem? foundItem = null;
        for (int i = 0; i < _items.Count; i++)
        {
            if (_items[i].Id == itemId)
            {
                foundItem = _items[i];
                break;
            }
        }
        if (foundItem != null)
        {
            _items.Remove(foundItem);
            _updatedAt = DateTime.Now;
        }
    }

    public ScheduleItem? GetItemById(string itemId)
    {
        for (int i = 0; i < _items.Count; i++)
        {
            if (_items[i].Id == itemId)
            {
                return _items[i];
            }
        }
        return null;
    }

    public List<ScheduleItem> GetItemsByDate(DateTime date)
    {
        List<ScheduleItem> result = new List<ScheduleItem>();
        for (int i = 0; i < _items.Count; i++)
        {
            ScheduleItem current = _items[i];
            if (current is TaskItem task)
            {
                if (task.Deadline.Date == date.Date)
                    result.Add(current);
            }
            else if (current is EventItem ev && ev.TimeRange != null)
            {
                if (ev.TimeRange.StartTime.Date <= date.Date && ev.TimeRange.EndTime.Date >= date.Date)
                    result.Add(current);
            }
            else if (current is ReminderItem reminder)
            {
                if (reminder.RemindTime.Date == date.Date)
                    result.Add(current);
            }
        }
        return result;
    }

    public List<ScheduleItem> GetItemsByPriority(Priority priority)
    {
        List<ScheduleItem> result = new List<ScheduleItem>();
        for (int i = 0; i < _items.Count; i++)
        {
            if (_items[i].Priority == priority)
            {
                result.Add(_items[i]);
            }
        }
        return result;
    }

    public List<ScheduleItem> SearchItems(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword))
            return new List<ScheduleItem>();

        List<ScheduleItem> result = new List<ScheduleItem>();
        for (int i = 0; i < _items.Count; i++)
        {
            ScheduleItem current = _items[i];
            bool titleMatch = current.Title != null && current.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase);
            bool descMatch = current.Description != null && current.Description.Contains(keyword, StringComparison.OrdinalIgnoreCase);
            if (titleMatch || descMatch)
            {
                result.Add(current);
            }
        }
        return result;
    }

    public void UpdateItem(ScheduleItem item)
    {
        int index = -1;
        for (int i = 0; i < _items.Count; i++)
        {
            if (_items[i].Id == item.Id)
            {
                index = i;
                break;
            }
        }
        if (index >= 0)
        {
            _items[index] = item;
            _updatedAt = DateTime.Now;
        }
    }

    public void ClearCompleted()
    {
        List<ScheduleItem> remaining = new List<ScheduleItem>();
        for (int i = 0; i < _items.Count; i++)
        {
            if (_items[i].Status != Status.Done)
            {
                remaining.Add(_items[i]);
            }
        }
        _items = remaining;
        _updatedAt = DateTime.Now;
    }
}