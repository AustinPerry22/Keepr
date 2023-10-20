

namespace Final.Services;
public class VaultsService
{
    private readonly VaultsRepository _repo;

    public VaultsService(VaultsRepository repo)
    {
        _repo = repo;
    }

    internal Vault CreateVault(Vault vaultData)
    {
        Vault newVault = _repo.CreateVault(vaultData);
        return newVault;
    }

    internal Vault GetVaultById(int vaultId, string userId)
    {
        Vault vault = _repo.GetVaultById(vaultId);
        if (vault.isPrivate == true && vault.creatorId != userId) throw new Exception("This vault is private");
        return vault;
    }

    internal Vault EditVault(Vault vaultData, int vaultId)
    {
        Vault ogVault = this.GetVaultById(vaultId, vaultData.creatorId);
        if (ogVault.creatorId != vaultData.creatorId) throw new Exception("Not your vault");
        ogVault.name = vaultData.name ?? ogVault.name;
        ogVault.description = vaultData.description ?? ogVault.description;
        ogVault.img = vaultData.img ?? ogVault.img;
        ogVault.isPrivate = vaultData.isPrivate ?? ogVault.isPrivate;
        _repo.EditVault(ogVault);
        return ogVault;

    }

    internal void DeleteVault(int vaultId, string userId)
    {
        Vault vaultToCheck = this.GetVaultById(vaultId, userId);
        if (userId != vaultToCheck.creatorId) throw new Exception("Not your vault");
        _repo.DeleteVault(vaultId);
    }
}