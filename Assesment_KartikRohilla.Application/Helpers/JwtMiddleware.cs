using Assesment_KartikRohilla.SharedLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Application.Helpers
{
    public class JwtMiddleware
    {

        private readonly RequestDelegate _next;
        private readonly JWTSettings _jwtSettings;

        public JwtMiddleware(RequestDelegate next, IOptions<JWTSettings> jwtSettings)
        {
            _next = next;
            _jwtSettings = jwtSettings.Value;
        }


        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
            {
                attachUserToContext(context, token);
            }

            await _next(context);
        }

        private async Task attachUserToContext(HttpContext context, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);


                var jwtToken = (JwtSecurityToken)validatedToken;
                int id = jwtToken.Claims.First(x => x.Type == "id").Value != null ? Convert.ToInt32(jwtToken.Claims.First(x => x.Type == "id").Value) : 0;
                string email = jwtToken.Claims.First(x => x.Type == "email").Value != null ? (jwtToken.Claims.First(x => x.Type == "email").Value).ToString() : null;

                context.Items["Id"] = id;
                context.Items["Email"] = email;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
