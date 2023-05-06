using authetication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace authetication.Controllers
{
    public class foodController : ApiController
    {
        authenticationEntities1 contex=new authenticationEntities1();
        public List<Foodlist> GET()
        {
            return contex.Foodlists.ToList();
        }
        public Foodlist GET(int id)
        {
            return contex.Foodlists.Where(a=>a.Id==id).FirstOrDefault();
        }
        public void Delete(int id)
        {
            Foodlist f1=contex.Foodlists.Where(a=>a.Id==id).FirstOrDefault();
            contex.Foodlists.Remove(f1);
            contex.SaveChanges();
        }
        public void Post(Foodlist add)
        {
           contex.Foodlists.Add(add);
            contex.SaveChanges();
        }
        public void put(Foodlist newdata)
        {
            Foodlist olddata = contex.Foodlists.Where(a => a.Id ==newdata.Id).FirstOrDefault();
            olddata.Name=newdata.Name;
            olddata.Price=newdata.Price;
            contex.SaveChanges();
        }
    }
}
