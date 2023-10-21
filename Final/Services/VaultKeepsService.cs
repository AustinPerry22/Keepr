

namespace Final.Services;
public class VaultKeepsService
{
    private readonly VaultKeepsRepository _repo;
    private readonly VaultsService _vaultsService;
    public VaultKeepsService(VaultKeepsRepository repo, VaultsService vaultsService)
    {
        _repo = repo;
        _vaultsService = vaultsService;
    }

    internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData)
    {
        Vault vault = _vaultsService.GetVaultById(vaultKeepData.vaultId, vaultKeepData.creatorId);
        if (vault.creatorId != vaultKeepData.creatorId) throw new Exception("not your vault");
        VaultKeep vaultKeep = _repo.CreateVaultKeep(vaultKeepData);
        return vaultKeep;
    }


    internal List<KeepViewModel> GetKeepsInVault(int vaultId, string userId)
    {
        // throws execption if vault is private.
        Vault vault = _vaultsService.GetVaultById(vaultId, userId);
        List<KeepViewModel> keeps = _repo.GetKeepsInVault(vaultId, userId);
        return keeps;
    }

    internal void DeleteVaultKeep(int vaultKeepId, string userId)
    {
        VaultKeep vaultKeep = this.GetVaultKeepById(vaultKeepId);
        if (vaultKeep.creatorId != userId) throw new Exception("not your vault keep!");
        _repo.DeleteVaultKeep(vaultKeepId);
    }

    // Not called from controller
    private VaultKeep GetVaultKeepById(int vaultKeepId)
    {
        VaultKeep vaultKeep = _repo.GetVaultKeepById(vaultKeepId);
        return vaultKeep;
    }


}