namespace Final.Controllers
{
    [ApiController]
    [Route("api/profiles")]
    public class ProfilesController : ControllerBase
    {
        private readonly ProfilesService _profilesService;
        private readonly Auth0Provider _auth0;
        public ProfilesController(ProfilesService profilesService, Auth0Provider auth0)
        {
            _profilesService = profilesService;
            _auth0 = auth0;
        }
    }
}