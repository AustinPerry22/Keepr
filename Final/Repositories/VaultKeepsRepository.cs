



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
            keepmodel.vaultKeepId = vaultkeep.id;
            return keepmodel;
        }, new { vaultId }).ToList();

        return keeps;
    }

    internal void DeleteVaultKeep(int vaultKeepId)
    {
        string sql = @"
        DELETE FROM vaultKeeps
        WHERE id = @vaultKeepId
        ;";
        _db.Execute(sql, new { vaultKeepId });
    }
}