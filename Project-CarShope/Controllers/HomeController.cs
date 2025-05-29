using DAL;
using Microsoft.AspNetCore.Mvc;
using Project_CarShope.Models;
using System.Diagnostics;
using BE;
using Messages = Project_CarShope.Models.Messages;
using Project_CarShope.Models;

namespace Project_CarShope.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //[HttpGet]
        //public IActionResult SendMess()
        //{
        //    return View();
        //}
        [HttpPost]
        public IActionResult SendMess(Messages  mess)
        {
            if (ModelState.IsValid)
            {
                var newMess = new BE.Messages
                {
                    FullName=mess.FullName,
                    Email=mess.Email,
                    TeaxMess=mess.TeaxMess,
                    DateReceived = DateTime.Now
                };
                using( var db = new DB())
                {
                    db.message.Add(newMess);
                    db.SaveChanges();
                }

                //mess.DateReceived = DateTime.Now;
            
                //ViewBag.Success = "پیام شما با موفقیت ارسال شد";
                return Ok();
            }
            return BadRequest();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult AdminLogin()
        {
            HttpContext.Session.SetString("Admin", "true");
            //CookieOptions options = new CookieOptions();
            //options.Expires=DateTime.Now.AddHours(4);
            //Response.Cookies.Append("Admin", "true", options);
            return RedirectToAction("Index", "Home");
        } 
        public IActionResult AdminLogout()
        {
            HttpContext.Session.Remove("Admin");
            //Response.Cookies.Delete("Admin");
            return RedirectToAction("Index", "Home");
        }

    }
}
