namespace Final.Controllers
{
    [ApiController]
    [Route("api/profiles")]
    public class ProfilesController : ControllerBase
    {
        private readonly ProfilesService _profilesService;

        private readonly KeepsService _keepsService;
        private readonly Auth0Provider _auth0;
        public ProfilesController(ProfilesService profilesService, KeepsService keepsService, Auth0Provider auth0)
        {
            _profilesService = profilesService;
            _keepsService = keepsService;
            _auth0 = auth0;
        }

        [HttpGet("{profileId}")]
        public ActionResult<Profile> GetProfileById(string profileId)
        {
            try
            {
                Profile profile = _profilesService.GetProfileById(profileId);
                return Ok(profile);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{profileId}/keeps")]
        public ActionResult<List<Keep>> GetKeepsByProfile(string profileId)
        {
            try
            {
                List<Keep> keeps = _keepsService.GetKeepsByProfile(profileId);
                return keeps;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}