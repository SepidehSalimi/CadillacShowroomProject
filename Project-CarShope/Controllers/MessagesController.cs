using Microsoft.AspNetCore.Mvc;
using BLL;
using BE;
using DAL;
using Microsoft.EntityFrameworkCore;

namespace Project_CarShope.Controllers
{
    public class MessagesController : Controller
    {
        BLL.BLMessages blm=new BLMessages();

       DB db = new DB();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowallMess()
        {
            var messages=blm.getallMess();
            return View(messages);
        }

        [HttpPost]
        public IActionResult SubmitMess(Messages messages)
        {
            if (ModelState.IsValid)
            {
                messages.DateReceived = DateTime.Now;   
                blm.addMess(messages);
                return RedirectToAction("ShowallMess");
            }
            return View("Contact",messages);  
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {

            var mess = blm.getMessbyId(id);
            if (mess == null)
            {
                return NotFound();
            }

            blm.Delete(mess);
            var result = blm.PaginationAndSearch("", 1);
            return PartialView("_searchPartial", result);

            
          
            
          
        }

        public IActionResult search(string search)
        {
           
            var result = blm.PaginationAndSearch(search, 1);
            return PartialView("_searchPartial", result);
        }

      

    }
}
