using authetication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace authetication.Controllers
{
    
    public class FoodlistController : Controller
    {
        authenticationEntities1 context = new authenticationEntities1();
        // GET: Foodlist
        public ActionResult Foodview()
        {
            int cu_id = Convert.ToInt32(Session["currentUser"]);
            TBLUser u = context.TBLUsers.Where(a => a.Id_Pk == cu_id).FirstOrDefault();
            String name = context.TBLUsers.Where(a => a.Id_Pk == cu_id).Select(a => a.Name).FirstOrDefault();
            string role = context.TBLUserTypes.Where(a => a.Id == u.User_Type_Fk).Select(a => a.UserType).SingleOrDefault();
            if (role == "Admin")
                return PartialView("Fooddata", context.Foodlists.ToList());
            return RedirectToAction("Login", "Home");
        }
        public ActionResult Add()
        {
            int cu_id = Convert.ToInt32(Session["currentUser"]);
            TBLUser u = context.TBLUsers.Where(a => a.Id_Pk == cu_id).FirstOrDefault();
            String name = context.TBLUsers.Where(a => a.Id_Pk == cu_id).Select(a => a.Name).FirstOrDefault();
            string role = context.TBLUserTypes.Where(a => a.Id == u.User_Type_Fk).Select(a => a.UserType).SingleOrDefault();
            if (role == "Admin")
                return View();
            return RedirectToAction("Login", "Home");
        }
        public ActionResult Editrecoad(int id)
        {
             int cu_id = Convert.ToInt32(Session["currentUser"]);
            TBLUser u = context.TBLUsers.Where(a => a.Id_Pk == cu_id).FirstOrDefault();
            String name = context.TBLUsers.Where(a => a.Id_Pk == cu_id).Select(a => a.Name).FirstOrDefault();
            string role = context.TBLUserTypes.Where(a => a.Id == u.User_Type_Fk).Select(a => a.UserType).SingleOrDefault();
            if (role == "Admin")
            {
                Foodlist olddata = context.Foodlists.Where(a => a.Id == id).FirstOrDefault();
                return View(olddata);
            }
            return RedirectToAction("Login", "Home");
        }
    }
}