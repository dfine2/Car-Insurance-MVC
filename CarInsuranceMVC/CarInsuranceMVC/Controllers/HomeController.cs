using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarInsuranceMVC.Models;

namespace CarInsuranceMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            TempData["user"] = new user();

            return View();
        }

        [HttpPost]
        public ActionResult Next1(string firstName, string lastName, DateTime DateOfBirth, string EmailAddress)
        {
            if (string.IsNullOrEmpty(firstName) || (string.IsNullOrEmpty(lastName) || DateOfBirth == null))
            {

                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {
                using (CarInsuranceMVCEntities3 db = new CarInsuranceMVCEntities3())
                {
                    if (TempData.ContainsKey("user"))
                    {
                        var app = TempData["user"] as user;
                        app.FirstName = firstName;
                        app.LastName = lastName;
                        app.DateOfBirth = DateOfBirth;
                        app.EmailAddress = EmailAddress;

                        //db.users.Add(app);
                        db.SaveChanges();
                        TempData.Keep("user");
                    }



                }
            }

            return RedirectToAction("Form2");
        }

        public ActionResult Form2()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Next2(int CarYear, string CarMake, string CarModel)
        {
            if (CarYear <= 0 || (string.IsNullOrEmpty(CarMake)) || (string.IsNullOrEmpty(CarModel)))
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {
                using (CarInsuranceMVCEntities3 db = new CarInsuranceMVCEntities3())
                {
                    if (TempData.ContainsKey("user"))
                    {
                        var app = TempData["user"] as user;
                        app.CarYear = CarYear;
                        app.CarMake = CarMake;
                        app.CarModel = CarModel;

                        //db.users.Add(app);
                        db.SaveChanges();
                        TempData.Keep("user");
                    }


                }
            }

            return RedirectToAction("Form3");
        }

        public ActionResult Form3(user app)
        {
            return View();
        }

        public ActionResult Submit(string DUI_radios, int tickets, string CoverageType)
        {
            if ((DUI_radios == null) || string.IsNullOrEmpty(CoverageType))
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {
                using (CarInsuranceMVCEntities3 db = new CarInsuranceMVCEntities3())
                {
                    if (TempData.ContainsKey("user"))
                    {
                        var app = TempData["user"] as user;
                        switch (DUI_radios)
                        {
                            case "no":
                                app.DUI = false;
                                break;
                            case "yes":
                                app.DUI = true;
                                break;
                            default:
                                return View("~/Views/Shared/Error.cshtml");
                        }

                        app.Tickets = tickets;
                        app.CoverageType = CoverageType;

                        db.users.Add(app);
                        db.SaveChanges();
                        TempData.Keep("user");
                    }
                }


                return RedirectToAction("Quote");
            }
        }
        public ActionResult Quote()
        {
            using (CarInsuranceMVCEntities3 db = new CarInsuranceMVCEntities3())
            {
                if (TempData.ContainsKey("user"))
                {
                    var app = TempData["user"] as user;
                    

                    return View(app);
                }
                else return View("~/Views/Shared/Error.cshtml");
            }
           

        }

        public ActionResult GoHome()
        {
            return RedirectToAction("Index");
        }
    }
        
}
   