using System.Web;
using JudoModelsLibrary;
using JudoMVC.Models;
using JudoServiceLibrary;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JudoMVC.Services
{
    public class UserService
    {
        public Verantwoordelijke GetCurrentVerantwoordelijke()
        {
            //Get current user
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(HttpContext.Current.User.Identity.GetUserId());

            //Get verantwoordelijke by email from current user
            var verantwService = new VerantwoordelijkeService();
            return verantwService.GetVerantwoordelijkeByEmail(currentUser.Email);
        }

        public Club GetCurrentClub()
        {
            //Get current user
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(HttpContext.Current.User.Identity.GetUserId());

            //Get club by email from current user
            var clubService = new ClubService();
            return clubService.GetClubByEmailWithGemeenteAndLand(currentUser.Email);
        }
    }
}