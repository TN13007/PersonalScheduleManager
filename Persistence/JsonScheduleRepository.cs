using System.Text.Json;

public class JsonScheduleRepository : IScheduleRepository
{
    private string _filePath;

    private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
    {
        WriteIndented = true,
        PropertyNameCaseInsensitive = true
    };

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
        string json = SerializeSchedule(schedule);
        File.WriteAllText(_filePath, json);
    }

    public Schedule Load()
    {
        if (!Exists())
            return new Schedule();

        string json = File.ReadAllText(_filePath);
        return DeserializeSchedule(json);
    }

    public void Delete()
    {
        if (Exists())
            File.Delete(_filePath);
    }

    public bool Exists()
    {
        return File.Exists(_filePath);
    }

    private string SerializeSchedule(Schedule schedule)
    {
        return JsonSerializer.Serialize(schedule, _jsonOptions);
    }

    private Schedule DeserializeSchedule(string jsonContent)
    {
        Schedule? schedule = JsonSerializer.Deserialize<Schedule>(jsonContent, _jsonOptions);
        return schedule ?? new Schedule();
    }
}