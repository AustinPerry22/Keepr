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

        // INTERALS
    }
}