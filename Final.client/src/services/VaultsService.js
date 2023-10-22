import { AppState } from "../AppState"
import { Vault } from "../models/Vault"
import { api } from "./AxiosService"

class VaultsService{
    async getVaultsByProfile(profileId)
    {
        const res = await api.get(`api/profiles/${profileId}/vaults`)
        AppState.activeVaults = res.data.map(vault=> new Vault(vault))
    }
}
export const vaultsService = new VaultsService()