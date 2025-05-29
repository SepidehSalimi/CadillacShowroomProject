using BE;

namespace Project_CarShope.Models
{
    public class Cars
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public int Year { get; set; }
        public float? Price { get; set; }
        public string? Descript { get; set; }
        public IFormFile Images { get; set; }
      


    }
}
