using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Microsoft.IdentityModel.Claims;
using Microsoft.AspNet.SignalR.Hubs;
using RolePrincipal.Hubs;
using Microsoft.AspNet.SignalR;

namespace RolePrincipal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var claims = (User.Identity as IClaimsIdentity).Claims;
            var nameClaim = claims.SingleOrDefault(c => c.ClaimType == "name");
            if (nameClaim != null)
            {
                ViewBag.name = nameClaim.Value;
            }

            return View();
        }

        [HttpPost]
        public void sendMessage(String messageToSend)
        {
            //Retrieving user's name
            var claims = (User.Identity as IClaimsIdentity).Claims;
            var nameClaim = claims.SingleOrDefault(c => c.ClaimType == "name");
            if (nameClaim != null)
            {
                var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
                context.Clients.All.addNewMessageToPage(nameClaim.Value, messageToSend);
            }
        }

        [HttpPost]
        public void logOut()
        {
            //Loggin out
            ClaimsCookie.ClaimsCookieModule.Instance.SignOut();
        }
    }
}
