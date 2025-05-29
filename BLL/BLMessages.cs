using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class BLMessages
    {
        DAMessages dal=new DAMessages();
        public List<Messages> getallMess() => dal.getallMess();

        public void addMess(Messages message)
        {
            dal.addMess(message);
        }
        public Messages getMessbyId(int id) => dal.getMessbyId(id);

        public void Delete(Messages m)
        {
            dal.Delete(m);
        }

        public List<Messages> PaginationAndSearch(string text, int page)
        {
            return dal.PaginationAndSearch(text, page);
        }
        public List<Messages> search(List<String> lstsearch)
        {
            return dal.search(lstsearch);
        }
        public List<Messages> search(string text)
        {

            return dal.search(text);

        }
        public List<Messages> searchbylist(List<String> lstsearch)
        {
            return dal.searchbylist(lstsearch);
        }
        public Messages searchbyid(int id)
        {
            return dal.searchbyid(id);
        }

    }
}
