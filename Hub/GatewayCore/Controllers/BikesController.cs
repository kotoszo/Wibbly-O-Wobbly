using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GatewayCore.Controllers
{
    [Produces("application/json")]
    [Route("api/Bikes")]
    public class BikesController : Controller
    {
    }
}