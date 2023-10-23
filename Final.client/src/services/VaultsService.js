import { AppState } from "../AppState"
import { Vault } from "../models/Vault"
import { api } from "./AxiosService"

class VaultsService{
    async getVaultsByProfile(profileId)
    {
        const res = await api.get(`api/profiles/${profileId}/vaults`)
        AppState.activeVaults = res.data.map(vault=> new Vault(vault))
    }
    async getMyVaults()
    {
        const res = await api.get('account/vaults')
        AppState.activeVaults = res.data.map(vault=> new Vault(vault))
    }

    async getVaultById(vaultId)
    {
        const res = await api.get('api/vaults/'+vaultId)
        AppState.activeVault = new Vault(res.data)
    }
}
export const vaultsService = new VaultsService()