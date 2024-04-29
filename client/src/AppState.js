import { reactive } from 'vue'
import { Keep, KeepInVault } from './models/Keep.js'
import { Vault } from './models/Vault.js'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  /** @type {import('./models/Account.js').Account} */
  account: {},
  /**@type {Keep[]} */
  allKeeps: [],
  /**@type {Keep[]} */
  profileKeeps: [],
  /**@type {KeepInVault[]} */
  vaultKeeps: [],
  /**@type {Keep[]} */
  myKeeps: [],
  /**@type {Keep || KeepInVault} */
  activeKeep: {},
  /**@type {Profile} */
  activeProfile: {},
  /**@type {Vault[]} */
  profileVaults: [],
  /**@type {Vault[]} */
  myVaults: [],
  /**@type {Vault} */
  activeVault: {}
})
