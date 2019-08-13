using CarInsuranceMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsuranceMVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            var quotes = new List<user>();
            using (CarInsuranceMVCEntities3 db = new CarInsuranceMVCEntities3())
            {
                var userList = db.users.ToList();
                foreach (var x in userList)
                {
                    quotes.Add(x);
                }
            }
                return View(quotes);
        }
    }
}