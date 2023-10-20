using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Final.Controllers
{
    [ApiController]
    [Route("api/vaults")]
    public class VaultsController : ControllerBase
    {
        private readonly Auth0Provider _auth0;
        private readonly VaultsService _vaultsService;

        public VaultsController(Auth0Provider auth0, VaultsService vaultsService)
        {
            _auth0 = auth0;
            _vaultsService = vaultsService;
        }
    }
}
