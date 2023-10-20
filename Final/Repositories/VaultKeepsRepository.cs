

namespace Final.Repositories;
public class VaultKeepsRepository
{
    private readonly IDbConnection _db;

    public VaultKeepsRepository(IDbConnection db)
    {
        _db = db;
    }

    internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData)
    {
        string sql = @"
        INSERT INTO vaultKeeps
        (creatorId, vaultId, keepId)
        VALUES
        (@creatorId, @vaultId, @keepId);

        SELECT
        *
        FROM vaultKeeps
        WHERE id = LAST_INSERT_ID()
        ;";
        VaultKeep vaultKeep = _db.Query<VaultKeep>(sql, vaultKeepData).FirstOrDefault();
        return vaultKeep;
    }

    // ANCHOR All results include Relationship Id vaultKeepId | AssertionError: Not All Keeps returned with vaultKeepId, be sure to return VaultKeepViewModels: expected false to deeply equal true
    internal List<KeepViewModel> GetKeepsInVault(int vaultId, string userId)
    {
        string sql = @"
        SELECT 
        vkep.*,
        kep.*,
        acc.*
        FROM vaultKeeps vkep
        JOIN keeps kep ON kep.id = vkep.keepId
        JOIN accounts acc ON acc.id = kep.creatorId 
        WHERE vaultId = @vaultId
        ;";
        List<KeepViewModel> keeps = _db.Query<VaultKeep, KeepViewModel, Account, KeepViewModel>(sql, (vaultkeep, keepmodel, account) =>
        {
            keepmodel.creator = account;
            return keepmodel;
        }, new { vaultId }).ToList();

        return keeps;
    }
}