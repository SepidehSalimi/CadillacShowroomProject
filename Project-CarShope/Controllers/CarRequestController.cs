using Microsoft.AspNetCore.Mvc;
using BLL;
using BE;
using Project_CarShope.Models;
using DAL;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Project_CarShope.Controllers
{
    public class CarRequestController : Controller
    {
        BLL.BLCarRequest blr = new BLCarRequest();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowallReq()
        {
            var reqest = blr.getallReq();
            return View(reqest);
        }

        [HttpGet]
        public IActionResult RequestInsp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitMess(BE.CarRequest request)
        {
            if (ModelState.IsValid)
            {
                request.ReqDate = DateTime.Now;
                blr.addReq(request);
                return RedirectToAction("ShowallReq");
            }
            return View("RequestInsp", request);
        }

        public IActionResult search(string search)
        {
            BLCarRequest blr = new BLCarRequest();
            var result = blr.PaginationAndSearch(search, 1);
            return PartialView("_searchPartial", result);
        }

        [HttpGet]
        public IActionResult Expert()
        {
            return View();
        }  
        [HttpPost]
        public IActionResult Expert(BE.CarRequest carR)
        {
            DB db = new DB();
            if (ModelState.IsValid)
            {
                db.carReq.Add(carR);
                db.SaveChanges();
                //ViewBag.Success = "درخواست با موفقیت ثبت شد";
                //ModelState.Clear();
                return Ok();
            }
            return BadRequest();
        }
    }
}
