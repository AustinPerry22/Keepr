import { AppState } from "../AppState"
import { Keep } from "../models/Keep"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class KeepsService
{
    async getAllKeeps()
    {
        const res = await api.get('api/keeps')
        AppState.allKeeps = res.data.map(keep=> new Keep(keep))
    }

    async getKeepsByProfile(profileId)
    {
        const res = await api.get(`api/profiles/${profileId}/keeps`)
        logger.log(res.data, "RES DATA")
        AppState.profileKeeps = res.data.map(keep=> new Keep(keep))
        logger.log("Appstate", AppState.profileKeeps)
    }

    async getKeepById(keepId)
    {
        const res = await api.get('api/keeps/'+keepId)
        AppState.activeKeep = new Keep(res.data)
    }
}
export const keepsService = new KeepsService()