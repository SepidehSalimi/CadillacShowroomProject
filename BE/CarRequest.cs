using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
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
