using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using System.Text;
using MircheeMusicAPI.Filters;




namespace MircheeMusicAPI.Filters
{
    public class MircheeMusicAuthorizeAttribute: AuthorizationFilterAttribute
    {

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var authHeader = actionContext.Request.Headers.Authorization;
            if (authHeader != null)
            {
                if(authHeader.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase) && !string.IsNullOrEmpty(authHeader.Parameter))
                {
                    var rawcredentials = authHeader.Parameter;
                    //var arrayCred = rawcredentials.Split(':');
                    //var username = arrayCred(0);
                    //var password = arrayCred(1);
                    //var encoding = Encoding.GetEncoding("");
                    var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(rawcredentials));
                    //var credentials = Convert.FromBase64String(rawcredentials);
                    var myStuff = credentials;
                    //if (CheckLogin(username, password))
                    //{
                    //    // Yes you are authorized!
                    //}

                }
                else
                {
                    HandleUnauthorize(actionContext);
                }

            }
            else
            {
                HandleUnauthorize(actionContext);
            }
            
        }

        private void HandleUnauthorize(HttpActionContext actionContext)
        {
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            //actionContext.Response.Headers.Add("www-authenticate", "Basic Scheme = 'MyAPI' location = ''" ); not sure how the location stuff works
        }
    }
}