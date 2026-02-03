/*
 * Rohith Pulyala
 * CIS 174
 * 1/20/2026
 */

using FirstResponsiveWebAppPulyala.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstResponsiveWebAppPulyala.Controllers
{
    public class HomeController : Controller
    {
        // Action method displays a blank input form.
        [HttpGet]
        public IActionResult Index()
        {
            return View(new PersonInfoModel());
        }

        // Post requests are sent through action method.
        [HttpPost]
        public IActionResult Index(PersonInfoModel model) 
        {
            if (ModelState.IsValid) 
            {
                ViewBag.AgeResult = model.AgeThisYear();
            }
            return View(model);
        }
    }
}
