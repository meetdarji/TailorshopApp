using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;


namespace TailorShopWebApi
{
    public class AuthRepository
    {
        public bool ValidateUser(string username, string password)
        {
            //TODO: Logic to validate username & password from database

            TailorShopEntities context = new TailorShopEntities();

            var q = from p in context.AspNetUsers
                    where p.UserName == username
                    && p.PasswordHash == password
                    select p;
            if (q.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}