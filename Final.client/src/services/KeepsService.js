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
}
export const keepsService = new KeepsService()