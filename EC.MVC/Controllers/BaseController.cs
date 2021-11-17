using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EC.MVC.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        private readonly IConfiguration _configuration;
        public BaseController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var sessions = context.HttpContext.Session.GetString("Token");
            
            if(sessions == null)
            {
                context.Result = new RedirectToActionResult("Index", "Login", null);
                base.OnActionExecuting(context);
            }
            else {
                var claims = this.VerifyToken(sessions);
                var currentUsserRole = claims.Claims.Where(c => c.Type == ClaimTypes.Role).FirstOrDefault();
                if (currentUsserRole != null)
                {
                    if (currentUsserRole.Value == "admin")
                    {
                        base.OnActionExecuting(context);
                    }
                    else
                    {
                        context.Result = new RedirectToActionResult("Index", "Login", null);
                        base.OnActionExecuting(context);
                    }

                }
                else
                {
                    context.Result = new RedirectToActionResult("Index", "Login", null);
                    base.OnActionExecuting(context);
                }
            }

            
        }
        private ClaimsPrincipal VerifyToken(string jwtToken)
        {
            IdentityModelEventSource.ShowPII = true;

            SecurityToken validatedToken;
            TokenValidationParameters validationParameters = new TokenValidationParameters();

            validationParameters.ValidateLifetime = true;

            validationParameters.ValidAudience = _configuration["Tokens:Issuer"];
            validationParameters.ValidIssuer = _configuration["Tokens:Issuer"];
            //Giải mã ra bằng KEY.
            validationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));
            //Trả về claim từ token giải mã.
            ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(jwtToken, validationParameters, out validatedToken);
            return principal;
        }

    }
}
