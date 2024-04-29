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

    internal Keep GetKeepById(int keepId, bool increaseView = false)
    {
        Keep keep = _repo.GetKeepById(keepId);
        if (keep == null) throw new Exception("no keep at id of " + keepId);
        if (increaseView)
        {
            this.increaseView(keep);
        }
        return keep;
    }

    internal Keep CreateKeep(Keep keepData)
    {
        Keep keep = _repo.CreateKeep(keepData);
        return keep;
    }

    internal Keep UpdateKeep(Keep keepData, int keepId)
    {
        Keep keepToUpdate = this.GetKeepById(keepId);
        if (keepToUpdate.creatorId != keepData.creatorId) throw new Exception("Not your Keep");
        keepToUpdate.name = keepData.name ?? keepToUpdate.name;
        keepToUpdate.description = keepData.description ?? keepToUpdate.description;
        keepToUpdate.img = keepData.img ?? keepToUpdate.img;
        _repo.UpdateKeep(keepToUpdate);
        return keepToUpdate;
    }

    internal void DeleteKeep(int keepId, string userId)
    {
        Keep keepToCheck = this.GetKeepById(keepId);
        if (userId != keepToCheck.creatorId) throw new Exception("Not your keep");
        _repo.DeleteKeep(keepId);
    }

    internal List<Keep> GetKeepsByProfile(string profileId)
    {
        List<Keep> keeps = _repo.GetKeepsByProfile(profileId);
        return keeps;
    }

    internal void increaseKept(int keepId)
    {
        Keep keep = this.GetKeepById(keepId);
        keep.kept++;
        _repo.UpdateKeep(keep);
    }

    internal void decreaseKept(int keepId)
    {
        Keep keep = this.GetKeepById(keepId);
        keep.kept--;
        _repo.UpdateKeep(keep);
    }

    private void increaseView(Keep keep)
    {
        keep.views++;
        _repo.UpdateKeep(keep);
    }
}