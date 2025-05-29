using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Project_CarShope
{
    public class uploadfile
    {
        private readonly IWebHostEnvironment _webhostenviroment;
        public uploadfile(IWebHostEnvironment webHostEnvironment)
        {
            _webhostenviroment = webHostEnvironment;
        }
        public string upload(IFormFile file)
        {
            if (file == null) return "";
            var path = _webhostenviroment.WebRootPath + "\\images\\cars\\" + file.FileName;
            using var f = System.IO.File.Create(path);
            file.CopyTo(f);
            return file.FileName;
        }

     
    }
}
