public class JsonScheduleRepository : IScheduleRepository
{
    private string _filePath;

    public string FilePath
    {
        get { return _filePath; }
        set { _filePath = value; }
    }

    public JsonScheduleRepository(string filePath)
    {
        _filePath = filePath;
    }

    public void Save(Schedule schedule)
    {
        throw new NotImplementedException();
    }

    public Schedule Load()
    {
        throw new NotImplementedException();
    }

    public void Delete()
    {
        throw new NotImplementedException();
    }

    public bool Exists()
    {
        throw new NotImplementedException();
    }

    private string SerializeSchedule(Schedule schedule)
    {
        throw new NotImplementedException();
    }

    private Schedule DeserializeSchedule(string jsonContent)
    {
        throw new NotImplementedException();
    }
}