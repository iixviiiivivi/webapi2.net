using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace webapi2.Filters
{
    public class ExceptionHandlerAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if(actionExecutedContext.Exception is Exception)
            {
                string actionName = actionExecutedContext.ActionContext.ActionDescriptor.ActionName;
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                response.Content = new StringContent($"Exception Caugth:{actionName} - {actionExecutedContext.Exception.Message}");
                actionExecutedContext.Response = response;
            }
        }
    }
}