using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JudoMVC.Models;
using JudoMVC.Services;

namespace JudoMVC.Controllers
{
    public class BankAccountController : BaseController
    {
        // GET: BankAccount
        public ActionResult Index()
        {
            return View();
        }

        //
        //GET: User/Toevoegen
        public ActionResult Toevoegen()
        {
            return View();
        }

        //
        //POST: User/Toevoegen
        [HttpPost]
        public ActionResult Toevoegen(RekeningnummerViewModel rekeningnummer)
        {
            if (ModelState.IsValid)
            {
                var userService = new UserService();
                var club = userService.GetCurrentClub();

                
            }
            return View();
        }
    }
}