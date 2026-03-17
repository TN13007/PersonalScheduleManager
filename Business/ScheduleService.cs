public class ScheduleService
{
    private Schedule _schedule;
    private ScheduleValidator _validator;

    public Schedule Schedule
    {
        get { return _schedule; }
        set { _schedule = value; }
    }

    public ScheduleValidator Validator
    {
        get { return _validator; }
        set { _validator = value; }
    }

    public ScheduleService()
    {
        _schedule = new Schedule();
        _validator = new ScheduleValidator();
    }

    public bool AddItemToSchedule(ScheduleItem item)
    {
        if (!_validator.ValidateItem(item))
            return false;

        _schedule.AddItem(item);
        return true;
    }

    public bool RemoveItemFromSchedule(string itemId)
    {
        ScheduleItem? item = _schedule.GetItemById(itemId);
        if (item == null)
            return false;

        _schedule.RemoveItem(itemId);
        return true;
    }

    public bool UpdateItemInSchedule(ScheduleItem item)
    {
        if (!_validator.ValidateItem(item))
            return false;

        ScheduleItem? existing = _schedule.GetItemById(item.Id);
        if (existing == null)
            return false;

        _schedule.UpdateItem(item);
        return true;
    }

    public List<ScheduleItem> GetAllItems()
    {
        return _schedule.Items;
    }

    public List<ScheduleItem> GetItemsByDate(DateTime date)
    {
        return _schedule.GetItemsByDate(date);
    }

    public List<ScheduleItem> GetItemsByPriority(Priority priority)
    {
        return _schedule.GetItemsByPriority(priority);
    }

    public List<ScheduleItem> SearchItems(string keyword)
    {
        return _schedule.SearchItems(keyword);
    }

    public List<ScheduleItem> GetConflictingItems(ScheduleItem item)
    {
        List<ScheduleItem> conflicts = new List<ScheduleItem>();
        List<ScheduleItem> allItems = _schedule.Items;
        for (int i = 0; i < allItems.Count; i++)
        {
            if (allItems[i].Id != item.Id && allItems[i].Overlaps(item))
            {
                conflicts.Add(allItems[i]);
            }
        }
        return conflicts;
    }

    public void DisplaySchedule()
    {
        List<ScheduleItem> items = _schedule.Items;
        if (items.Count == 0)
        {
            Console.WriteLine("No items in schedule.");
            return;
        }

        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {items[i].Display()}");
        }
    }

    public void DisplayScheduleByDate(DateTime date)
    {
        List<ScheduleItem> items = _schedule.GetItemsByDate(date);
        if (items.Count == 0)
        {
            Console.WriteLine($"No items found for {date:yyyy-MM-dd}.");
            return;
        }

        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {items[i].Display()}");
        }
    }
}