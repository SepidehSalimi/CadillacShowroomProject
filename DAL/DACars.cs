using BE;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace DAL
{
    public class DACars
    {
        DB db =new DB();
        public void create(Cars c)
        {
            db.car.Add(c);
            db.SaveChanges();
        }
        public Cars searchbyid(int id)
        {
            return db.car.Find(id);
        }

        public List<Cars> PaginationAndSearch(string text, int page)
        {
            if (page == 0)
            {
                page = 1;
            }
            int skip = (page - 1) * 10;
            return search(text).Skip(skip).Take(10).ToList();
        }

        public List<Cars> getall()
        {

            var q = from i in db.car select i;
            return q.ToList();
        }
        public List<Cars> search(string text)
        {
            
            if (text == "" || text == null)
            {
                return db.car.ToList();
            }
            return db.car.Where(q => q.Title.Contains(text)).ToList();
        }
        public double gettotal()
        {

            return db.car.Count();
        }
        public List<Cars> getskip(int c)
        {
            int t = c * 10;

            var q = db.car.Skip(t).Take(10);
            return q.ToList();
        }
        public List<Cars> search(List<String> lstsearch)
        {
            List<Cars> te = new List<Cars>();
            foreach (var item in lstsearch)
            {

                var q = from i in db.car
                        where i.Title.Contains(item.ToString())
                        select i;

                te = te.Concat(q.ToList()).ToList();
            }
            return te;
        }
        public void update(Cars c)
        {

            var q = from i in db.car
                    where i.Id == c.Id
                    select i;

            q.Single().Title = c.Title;
            q.Single().Brand = c.Brand;
            q.Single().Model = c.Model;
            q.Single().Year = c.Year;
            q.Single().Price = c.Price;
            q.Single().Descript = c.Descript;
            q.Single().ImagePath = c.ImagePath;
            db.SaveChanges();
        }

        public List<Cars> searchbylist(List<String> lstsearch)
        {
            List<Cars> ca = new List<Cars>();
            foreach (var item in lstsearch)
            {

                var q = search(item);
                ca = ca.Concat(q.ToList()).ToList();
            }
            return ca;
        }
        public void Delete(Cars carses)
        {
            db.Remove(carses);
            db.SaveChanges();
        }
    }
}
