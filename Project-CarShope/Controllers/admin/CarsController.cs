using BE;
using BLL;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Project_CarShope.Models;
//using Cars = Project_CarShope.Models.Cars;

namespace Project_CarShope.Controllers.admin
{
    public class CarsController : Controller
    {
        private IWebHostEnvironment Environment;

        public CarsController(IWebHostEnvironment _environment)
        {
            Environment = _environment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult KharidCar(string search)
        {
            ViewBag.searchtxt = search;
            return View();

             //       BLCars bls = new BLCars();
             //       List<BE.Cars> result;
             //if (!string.IsNullOrEmpty(search))
             //{
             //    result = bls.getall();
             //}
             //else
             //{
             //    result = bls.search(search);

             //}
        }


    public IActionResult Detail(int id)
        {
            DB db=new DB();
            BLCars blc = new BLCars();
            var car = blc.searchbyid(id);
            if (car==null)
            {
                return NotFound();
            }
          
            return View(car);

        }

        [HttpPost]
       
        public IActionResult create(Models.Cars c)
        {
            if (ModelState.IsValid)
            {
                string imgName = null;
                if (c.Images != null)
                {
                    imgName = Guid.NewGuid().ToString() +
                        Path.GetExtension(c.Images.FileName);
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/cars", imgName);
                    using(var stream=new FileStream(path,FileMode.Create))
                    {
                        c.Images.CopyTo(stream);
                    }
                }
                BE.Cars car = new BE.Cars
                {
                    Title = c.Title,
                    Price = c.Price,
                    Brand = c.Brand,
                    Model = c.Model,
                    Year = c.Year,
                    Descript = c.Descript,
                    ImagePath = imgName
                };
          
                DB db = new DB();
                db.car.Add(car);
                db.SaveChanges();

                return RedirectToAction(nameof(Showall));
            }
            

            return View(c);

        }
        public IActionResult Showall()
        {
            BLCars blt = new BLCars();
            return View("ShowCar", blt.getskip(0));
        }
        public IActionResult getskip(int c)
        {
            BLCars blt = new BLCars();
            return View("ShowCar", blt.getskip(c));
        }

        public IActionResult search(string search)
        {
            BLCars blc = new BLCars();
            var result = blc.PaginationAndSearch(search, 1);
            return PartialView("_searchPartial", result);
        }

        public IActionResult searchCar(string search)
        {
            BLCars blc = new BLCars();
            var result = blc.search(search);
            return PartialView("KharidCar", result);
        }

        public string update(Models.Cars c)
        {

            BLCars blt = new BLCars();

            var item = blt.searchbyid(c.Id);

            item.Title = c.Title;
            item.Price = c.Price;
            item.Year = c.Year;
            item.Brand = c.Brand;
            item.Model = c.Model;
            item.Descript = c.Descript;
            uploadfile uf = new uploadfile(Environment);
            if (c.Images != null)
                item.ImagePath = uf.upload(c.Images);
            blt.update(item);
            return "ثبت شد";
        }

        [HttpPost]
        public IActionResult Delete(int iddelete)
        {
            BLCars blt = new BLCars();
            var tt = blt.searchbyid(iddelete);
            if (tt == null)
            {
                return NotFound();
            }

            blt.Delete(tt);
            var result = blt.PaginationAndSearch("", 1);
            return PartialView("_searchPartial", result);
        }


    }
}
