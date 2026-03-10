public interface IScheduleRepository
{
    void Save(Schedule schedule);

    Schedule Load();

    void Delete();

    bool Exists();
}