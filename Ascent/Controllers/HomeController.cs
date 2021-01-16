using Ascent.Models;
using Ascent.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Ascent.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly DepartmentService _departmentService;

        private readonly ILogger<HomeController> _logger;

        public HomeController(DepartmentService departmentService, ILogger<HomeController> logger)
        {
            _departmentService = departmentService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Departments = _departmentService.GetDepartments().Select(d => new SelectListItem
            {
                Text = d.Name,
                Value = d.Abbreviation.ToString()
            });
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
