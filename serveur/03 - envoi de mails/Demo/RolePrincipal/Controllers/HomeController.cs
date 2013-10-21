using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using Microsoft.IdentityModel.Claims;
using Microsoft.AspNet.SignalR.Hubs;
using RolePrincipal.Hubs;
using Microsoft.AspNet.SignalR;
using System.Net.Mail;

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
            /*var claims = (User.Identity as IClaimsIdentity).Claims;
            var nameClaim = claims.SingleOrDefault(c => c.ClaimType == "name");
            if (nameClaim != null)
            {
                var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
                context.Clients.All.addNewMessageToPage(nameClaim.Value, messageToSend);
            }*/
            MailMessage message = new MailMessage();
            message.From = new MailAddress("azure_3d645523d667d8129f431d9117c5d364@azure.com");
            message.To.Add(new MailAddress("david.poualailleau@capgemini.com"));

            message.Subject = "New message received";
            message.Body = messageToSend;
            SmtpClient client = new SmtpClient("smtp.sendgrid.net", 587);
            client.Credentials = new NetworkCredential("azure_3d645523d667d8129f431d9117c5d364@azure.com", "demoESEO");
            client.EnableSsl = true;
            client.Send(message);
        }
    }
}
