using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Serious.Users.AppCode
{
    public class UserHub : Hub
    {
        [Authorize(Roles = Constants.MASTER)]
        public void LogOff(string email)
        {
            UserManager.Instance.EndUserSession(email);
            //Context.User.
            //var userId = Microsoft.AspNet.Identity.IdentityExtensions.GetUserId(Context.User.Identity);
            //Clients.All.onLoggOutUser(email);
            Clients.User(email).onLoggOutUser(email);
        }
    }
}