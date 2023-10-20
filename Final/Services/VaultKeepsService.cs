
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
}