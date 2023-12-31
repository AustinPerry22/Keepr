import { AppState } from "../AppState"
import { Vault } from "../models/Vault"
import { api } from "./AxiosService"

class VaultsService{
    async getVaultsByProfile(profileId)
    {
        const res = await api.get(`api/profiles/${profileId}/vaults`)
        AppState.profileVaults = res.data.map(vault=> new Vault(vault))
    }
    async getMyVaults()
    {
        const res = await api.get('account/vaults')
        AppState.myVaults = res.data.map(vault=> new Vault(vault))
    }

    async getVaultById(vaultId)
    {
        const res = await api.get('api/vaults/'+vaultId)
        AppState.activeVault = new Vault(res.data)
    }

    async createVault(vaultData)
    {
        const res = await api.post('api/vaults', vaultData)
        AppState.activeVault = new Vault(res.data)
    }

    async deleteVault()
    {
        await api.delete('api/vaults/'+AppState.activeVault.id)
    }

    async removeKeepFromVault(keepId)
    {
        const vaultKeep = AppState.vaultKeeps.find(vaultKeep => vaultKeep.id == keepId)
        const vaultKeepIndex = AppState.vaultKeeps.findIndex(keep => keep.id == vaultKeep.id)
        AppState.vaultKeeps.splice(vaultKeepIndex, 1)
        await api.delete('api/vaultkeeps/'+vaultKeep.vaultKeepId)
    }
}
export const vaultsService = new VaultsService()