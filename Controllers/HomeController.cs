using authetication.App_Start;
using authetication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace authetication.Controllers
{
    public class HomeController : Controller
    {
        authenticationEntities1 context=new authenticationEntities1();
        // GET: Home
        [loginfilter]
        public ActionResult Login()
        {
            return View();
        }
        [loginfilter]
        public ActionResult DoLogin(TBLUser u)
        {
            TBLUser u1=context.TBLUsers.Where(a=>a.UserName==u.UserName && a.Password==u.Password).FirstOrDefault();
            if(u1!=null)
            {
                Session["currentUser"] = u1.Id_Pk;
                return RedirectToAction("Welcome");

            }
            ViewData["VerificationError"] = "Username or Paswword you entered are incorrect.";
            return View("Login");
        }
        [checkloginfitter]
        
        public ActionResult Welcome()
        {
           
            int cu_id = Convert.ToInt32(Session["currentUser"]);
            TBLUser u = context.TBLUsers.Where(a => a.Id_Pk == cu_id).FirstOrDefault();
            String name= context.TBLUsers.Where(a => a.Id_Pk == cu_id).Select(a=>a.Name).FirstOrDefault();
            string role = context.TBLUserTypes.Where(a => a.Id == u.User_Type_Fk).Select(a => a.UserType).SingleOrDefault();
            if(role=="Admin")
            {
                return View("AdminWelcome", null, name);
            }

             return View(null, null, name);
        }

    }
}