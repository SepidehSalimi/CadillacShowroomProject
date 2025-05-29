using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class DAMessages
    {
        DB db=new DB();

        public List<Messages> getallMess()=>db.message.ToList();//دریافت همه پیام ها

        public void addMess(Messages messages)
        {
            db.message.Add(messages);
            db.SaveChanges();
        }
        public Messages getMessbyId(int id) => db.message.Find(id);

        public void Delete(Messages m)
        {
            db.message.Remove(m);
            db.SaveChanges();
        }

        public List<Messages> PaginationAndSearch(string text, int page)
        {
            if (page == 0)
            {
                page = 1;
            }
            int skip = (page - 1) * 10;
            return search(text).Skip(skip).Take(10).ToList();
        }
        public List<Messages> search(string text)
        {
            if (text == "" || text == null)
            {
                return db.message.ToList();
            }
            return db.message.Where(q => q.FullName.Contains(text)).ToList();
        }

        public List<Messages> search(List<String> lstsearch)
        {
            List<Messages> te = new List<Messages>();
            foreach (var item in lstsearch)
            {

                var q = from i in db.message
                        where i.FullName.Contains(item.ToString())
                        select i;

                te = te.Concat(q.ToList()).ToList();
            }
            return te;
        }

        public Messages searchbyid(int id)
        {
            return db.message.Find(id);
        }

        public List<Messages> searchbylist(List<String> lstsearch)
        {
            List<Messages> ca = new List<Messages>();
            foreach (var item in lstsearch)
            {

                var q = search(item);
                ca = ca.Concat(q.ToList()).ToList();
            }
            return ca;
        }

    }
}
