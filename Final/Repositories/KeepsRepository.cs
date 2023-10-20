namespace Final.Repositories;
public class KeepsRepository
{
    private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
        _db = db;
    }
    // INTERALS  BELOW HERE
}