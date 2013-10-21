using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.AspNet.SignalR;
using Microsoft.IdentityModel.Claims;

namespace RolePrincipal.Hubs
{
    public class ChatHub : Hub
    {
        public void Send(string message)
        {
            // Call the addNewMessageToPage method to update clients.
            //Clients.All.addNewMessageToPage("Annon", message);
        }
    }
}