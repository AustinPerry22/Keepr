using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Final.Controllers
{
    [ApiController]
    [Route("api/keeps")]

    public class KeepsController : ControllerBase
    {
        private readonly Auth0Provider _auth0;
        private readonly KeepsService _keepsService;
        public KeepsController(Auth0Provider auth0, KeepsService keepsService)
        {
            _auth0 = auth0;
            _keepsService = keepsService;
        }
        // INTERNALS

        [HttpGet]
        public ActionResult<List<Keep>> GetKeeps()
        {
            try
            {
                List<Keep> keeps = _keepsService.GetKeeps();
                return Ok(keeps);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Keep>> CreateKeep([FromBody] Keep keepData)
        {
            try
            {
                Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
                keepData.creatorId = userInfo.Id;
                Keep keep = _keepsService.CreateKeep(keepData);
                return Ok(keep);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}