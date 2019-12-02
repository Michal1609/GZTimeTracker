using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GZTimeTracker.Administration.Areas.Administration.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        
    }
}