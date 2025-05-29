using BE;
using DAL;
using static System.Runtime.InteropServices.JavaScript.JSType;
using String = System.String;
namespace BLL
{
    public class BLCars
    {
        DACars dac=new DACars();
        public void create(Cars c)
        {
            dac.create(c);
        }
        public void update(Cars t)
        {
            dac.update(t);
        }
        public List<Cars> search(string text)
        {
            return dac.search(text);
        }
        public Cars searchbyid(int id)
        {
            return dac.searchbyid(id);
        }
        public List<Cars> PaginationAndSearch(string text, int page)
        {
            return dac.PaginationAndSearch(text, page);
        }
        public List<Cars> getall()
        {
            return dac.getall();
        }
        public List<Cars> getskip(int c)
        {
            return dac.getskip(c);
        }

        public double gettotal()
        {
            return dac.gettotal();
        }
        public List<Cars> search(List<String> lstsearch)
        {
            return dac.search(lstsearch);
        }

        public void Delete(Cars carses)
        {
            dac.Delete(carses);
        }

        public List<Cars> searchbylist(List<String> lstsearch)
        {
            return dac.searchbylist(lstsearch);
        }
    }
}
