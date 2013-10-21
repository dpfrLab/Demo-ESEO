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
            return View();
        }

        [HttpPost]
        public void sendMessage(String messageToSend)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
            context.Clients.All.addNewMessageToPage("Annon", messageToSend);
        }
    }
}
