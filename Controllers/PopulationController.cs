using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ZAVOD_KZZ.Controllers
{
    public class PopulationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}