using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Http;
using MircheeMusicAPI.Repository;

namespace MircheeMusicAPI.Filters
{
    public class WebSecurity
    {
        public Boolean Login(string UserName, string Password)
        {
            var LoginRepo = new LoginRepository();
            var Result = LoginRepo.Find(UserName, Password);
            if (Result == false)
            {
                var ErrMessage = string.Format("Resourse with id = {0} not found", UserName);
               // var ErrResponse = Request.CreateErrorResponse(HttpStatusCode.Unauthorized,ErrMessage);
                //throw new HttpResponseException(new HttpResponseException("oo"));
                throw new Exception();
            }
            else
            {
                return false;
            }
            
        }
    }
}