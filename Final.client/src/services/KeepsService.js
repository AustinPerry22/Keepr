import { AppState } from "../AppState"
import { Keep } from "../models/Keep"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class KeepsService
{
    async getAllKeeps()
    {
        AppState.keeps = []
        const res = await api.get('api/keeps')
        AppState.keeps = res.data.map(keep=> new Keep(keep))
    }

    async getKeepsByProfile(profileId)
    {
        AppState.keeps = []
        const res = await api.get(`api/profiles/${profileId}/keeps`)
        AppState.keeps = res.data.map(keep=> new Keep(keep))
    }

    async getVaultKeeps(vaultId)
    {
        AppState.keeps = []
        const res = await api.get(`api/vaults/${vaultId}/keeps`)
        AppState.keeps = res.data.map(keep=> new Keep(keep))
    }

    async getKeepById(keepId)
    {
        AppState.activeKeep = {}
        const res = await api.get('api/keeps/'+keepId)
        AppState.activeKeep = new Keep(res.data)
    }
}
export const keepsService = new KeepsService()