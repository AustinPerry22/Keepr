import { Profile } from "./Account"

export class Keep{
    constructor(data)
    {
        this.id = data.id
        this.creatorId = data.creatorId
        this.name = data.name
        this.description = data.description
        this.img = data.img
        this.views = data.views
        this.kept = data.kept
        this.creator = data.creator ? new Profile(data.creator) : null
    }
}

export class KeepInVault extends Keep{
    constructor(data)
    {
        super(data)
        this.vaultKeepId = data.vaultKeepId
        this.isPrivate = data.isPrivate
    }
}

