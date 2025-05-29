using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class DACarRequest
    {
        DB db = new DB();
        public List<CarRequest> getallReq() => db.carReq.ToList();

        public void addReq(CarRequest request)
        {
            db.carReq.Add(request);
            db.SaveChanges();
        }
        public CarRequest getReqbyId(int id) => db.carReq.Find(id);

        public List<CarRequest> PaginationAndSearch(string text, int page)
        {
            if (page == 0)
            {
                page = 1;
            }
            int skip = (page - 1) * 10;
            return search(text).Skip(skip).Take(10).ToList();
        }
        public List<CarRequest> search(string text)
        {
            if (text == "" || text == null)
            {
                return db.carReq.ToList();
            }
            return db.carReq.Where(q => q.FullName.Contains(text)).ToList();
        }

        public List<CarRequest> search(List<String> lstsearch)
        {
            List<CarRequest> te = new List<CarRequest>();
            foreach (var item in lstsearch)
            {

                var q = from i in db.carReq
                        where i.FullName.Contains(item.ToString())
                        select i;

                te = te.Concat(q.ToList()).ToList();
            }
            return te;
        }

        public CarRequest searchbyid(int id)
        {
            return db.carReq.Find(id);
        }

        public List<CarRequest> searchbylist(List<String> lstsearch)
        {
            List<CarRequest> ca = new List<CarRequest>();
            foreach (var item in lstsearch)
            {

                var q = search(item);
                ca = ca.Concat(q.ToList()).ToList();
            }
            return ca;
        }



    }
}
