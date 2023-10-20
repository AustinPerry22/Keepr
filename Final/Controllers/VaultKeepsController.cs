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
    }
}