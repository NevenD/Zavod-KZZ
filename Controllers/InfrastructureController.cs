using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace ZAVOD_KZZ.Controllers
{
    [AllowAnonymous]
    public class InfrastructureController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public InfrastructureController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}