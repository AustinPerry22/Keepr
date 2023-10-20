


namespace Final.Repositories;
public class VaultsRepository
{
    private readonly IDbConnection _db;

    public VaultsRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Vault CreateVault(Vault vaultData)
    {
        string sql = @"
        INSERT INTO vaults
        (creatorId, name, description, img, isPrivate)
        VALUES
        (@creatorId, @name, @description, @img, @isPrivate);

        SELECT
        val.*,
        acc.*
        FROM vaults val
        JOIN accounts acc ON acc.id = val.creatorId
        WHERE val.id = LAST_INSERT_ID()
        ;";
        Vault newVault = _db.Query<Vault, Account, Vault>(sql, (vault, account) =>
        {
            vault.creator = account;
            return vault;
        }, vaultData).FirstOrDefault();
        return newVault;
    }

    internal Vault GetVaultById(int vaultId)
    {
        string sql = @"
        SELECT
        val.*,
        acc.*
        FROM vaults val
        JOIN accounts acc ON acc.id = val.creatorId
        WHERE val.id = @vaultId
        ;";
        Vault vault = _db.Query<Vault, Account, Vault>(sql, (vault, account) =>
        {
            vault.creator = account;
            return vault;
        }, new { vaultId }).FirstOrDefault();
        return vault;
    }

    internal void EditVault(Vault ogVault)
    {
        string sql = @"
        UPDATE vaults
        SET
        name = @name,
        description = @description,
        img = @img,
        isPrivate = @isPrivate
        WHERE id = @id
        ;";
        _db.Execute(sql, ogVault);
    }
}