using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationLab.Controllers
{
    [Authorize(Policy ="Over21Only")]
    public class HomeController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
