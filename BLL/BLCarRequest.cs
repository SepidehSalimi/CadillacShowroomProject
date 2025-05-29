using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class BLCarRequest
    {
        DACarRequest dal=new DACarRequest();

        public List<CarRequest> getallReq() => dal.getallReq();

        public void addReq(CarRequest request)
        {
            dal.addReq(request);
           
        }
        public CarRequest getReqbyId(int id) => dal.getReqbyId(id);

        public List<CarRequest> searchbylist(List<String> lstsearch)
        {
            return dal.searchbylist(lstsearch);
        }
        public List<CarRequest> search(List<String> lstsearch)
        {
            return dal.search(lstsearch);
        }
        public List<CarRequest> search(string text)
        {

            return dal.search(text);

        }
        public CarRequest searchbyid(int id)
        {
            return dal.searchbyid(id);
        }
        public List<CarRequest> PaginationAndSearch(string text, int page)
        {
            return dal.PaginationAndSearch(text, page);
        }
    }
}
