using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascent.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ascent.Controllers
{
    [Authorize(Policy = Policy.CanReadDepartmentResources)]
    public class ProgramsController : Controller
    {
        public IActionResult Index(string dept)
        {
            ViewBag.Dept = dept;
            return View();
        }
    }
}
