using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Filters
{
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            int id = context.HttpContext.Items["Id"] != null ? Convert.ToInt32(context.HttpContext.Items["Id"]) : 0;
            string email = context.HttpContext.Items["Email"] != null ? (context.HttpContext.Items["Email"]).ToString() : null;
            if (id == 0 || email == null)
            {
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}
