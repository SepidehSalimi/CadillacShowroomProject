namespace Project_CarShope.Models
{
    public class CarRequest
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNum { get; set; }
        public string CarDetails { get; set; }
        public DateTime ReqDate { get; set; } = DateTime.Now;
    }
}
