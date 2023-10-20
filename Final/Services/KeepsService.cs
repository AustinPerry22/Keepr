


namespace Final.Services;

public class KeepsService
{
    private readonly KeepsRepository _repo;

    public KeepsService(KeepsRepository repo)
    {
        _repo = repo;
    }


    internal List<Keep> GetKeeps()
    {
        List<Keep> keeps = _repo.GetKeeps();
        return keeps;
    }

    internal Keep GetKeepById(int keepId)
    {
        Keep keep = _repo.GetKeepById(keepId);
        return keep;
    }
    internal Keep CreateKeep(Keep keepData)
    {
        Keep keep = _repo.CreateKeep(keepData);
        return keep;
    }


    // INTERNALS

}