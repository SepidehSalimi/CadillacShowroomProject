using BE;
using Microsoft.AspNetCore.Mvc;
using DAL;

namespace Project_CarShope.ViewComponents
{
    public class CarViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string search)
        {
            //BLL.BLCars blt = new BLL.BLCars();
            //var cars = string.IsNullOrEmpty(search)
            //    ? blt.getall() : blt.search(search);
            DACars dl=new DACars();
            var cars=dl.search(search);
            
            return View(cars);
        }
    }
}
//"_Car", blt.getall()