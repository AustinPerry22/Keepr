namespace Final.Controllers
{
    [ApiController]
    [Route("api/vaultkeeps")]
    public class VaultKeepsController : ControllerBase
    {
        private readonly Auth0Provider _auth0;
        private readonly VaultKeepsService _vaultKeepsService;

        public VaultKeepsController(Auth0Provider auth0, VaultKeepsService vaultKeepsService)
        {
            _auth0 = auth0;
            _vaultKeepsService = vaultKeepsService;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<VaultKeep>> CreateVaultKeep([FromBody] VaultKeep vaultKeepData)
        {
            try
            {
                Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
                vaultKeepData.creatorId = userInfo.Id;
                VaultKeep vaultKeep = _vaultKeepsService.CreateVaultKeep(vaultKeepData);
                return Ok(vaultKeep);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Authorize]
        [HttpDelete("{vaultKeepId}")]
        public async Task<ActionResult<string>> DeleteVaultKeep(int vaultKeepId)
        {
            try
            {
                Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
                _vaultKeepsService.DeleteVaultKeep(vaultKeepId, userInfo.Id);
                return Ok("VaultKeep deleted with id of " + vaultKeepId);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}