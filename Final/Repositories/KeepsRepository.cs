

namespace Final.Repositories;
public class KeepsRepository
{
    private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
        _db = db;
    }

    // INTERNALS
    internal List<Keep> GetKeeps()
    {
        string sql = @"
        SELECT
        kep.*,
        acc.*
        FROM keeps kep
        JOIN accounts acc ON acc.id = kep.creatorId
        ;";

        List<Keep> keeps = _db.Query<Keep, Account, Keep>(sql, (keep, account) =>
        {
            keep.creator = account;
            return keep;
        }).ToList();
        return keeps;
    }

    internal Keep CreateKeep(Keep keepData)
    {
        string sql = @"
        INSERT INTO keeps
        (creatorId, name, description, img, views)
        VALUES
        (@creatorId, @name, @description, @img, @views);
        
        SELECT
        kep.*,
        acc.*
        FROM keeps kep 
        JOIN accounts acc ON acc.id = kep.creatorId
        WHERE kep.id = LAST_INSERT_ID()
        ;";
        Keep newKeep = _db.Query<Keep, Account, Keep>(sql, (keep, account) =>
        {
            keep.creator = account;
            return keep;
        }, keepData).FirstOrDefault();
        return newKeep;
    }
}