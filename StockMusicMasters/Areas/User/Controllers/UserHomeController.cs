using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StockMusicMasters.Areas.User.Controllers
{
    [Area("User")]
    public class UserHomeController : Controller
    {
        public IActionResult UserIndex()
        {
            return View();
        }

        [Route("user/test")]
        public IActionResult Test()
        {
            return View();
        }
    }
}