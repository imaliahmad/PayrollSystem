﻿using Microsoft.AspNetCore.Mvc;

namespace PS.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
