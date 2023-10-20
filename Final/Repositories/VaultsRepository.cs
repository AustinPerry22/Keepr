namespace Final.Repositories;
public class VaultsRepository
{
    private readonly IDbConnection _repo;

    public VaultsRepository(IDbConnection repo)
    {
        _repo = repo;
    }

}