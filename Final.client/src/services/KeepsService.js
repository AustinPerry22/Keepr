import { AppState } from "../AppState"
import { Keep } from "../models/Keep"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class KeepsService
{
    async getAllKeeps()
    {
        AppState.allKeeps = []
        const res = await api.get('api/keeps')
        AppState.allKeeps = res.data.map(keep=> new Keep(keep))
    }
    async getKeepsByProfile(profileId)
    {
        AppState.profileKeeps = []
        if(profileId == undefined) profileId = AppState.account.id
        const res = await api.get(`api/profiles/${profileId}/keeps`)
        AppState.profileKeeps = res.data.map(keep=> new Keep(keep))
        if(profileId == AppState.account.id) AppState.myKeeps = AppState.profileKeeps
    }

    async getVaultKeeps(vaultId)
    {
        AppState.vaultKeeps = []
        const res = await api.get(`api/vaults/${vaultId}/keeps`)
        AppState.vaultKeeps = res.data.map(keep=> new Keep(keep))
    }

    async getKeepById(keepId)
    {
        AppState.activeKeep = {}
        const res = await api.get('api/keeps/'+keepId)
        AppState.activeKeep = new Keep(res.data)
    }

    async createKeep(keepData, route = null)
    {
        const res = await api.post('api/keeps', keepData)
        AppState.activeKeep = new Keep(res.data)
        if(route == "Home") AppState.allKeeps.push(AppState.activeKeep)
        if(route == "Account") AppState.myKeeps.push(AppState.activeKeep)
    }
}
export const keepsService = new KeepsService()