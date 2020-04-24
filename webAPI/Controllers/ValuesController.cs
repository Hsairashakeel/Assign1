using BAL_assign3;
using Entities_assign3;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;

namespace webAPI.Controllers
{
    [EnableCors(origins: "https://localhost:44384", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
       
        // GET api/values
        public string Get()
        {
            return "value";
        }

        [HttpGet]
        public Object GetToken(String name, String passw,String grant_type)
        {
            object data = null;
            try
            {

                var flag = false;
                bool result = UserBO.IsValidUser(name, passw);
                if (result == true)
                {
                    var dto = new UserDTO();
                    dto = UserBO.GetUserDataByLogin(name);
                    flag = true;
                    string key = "my_secret_key_12345";
                    var issuer = "http://mysite.com";
                    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                    var permClaims = new List<Claim>();
                    permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                    permClaims.Add(new Claim("valid", "1"));
                    permClaims.Add(new Claim("userid", dto.UserID.ToString()));
                    var token = new JwtSecurityToken(issuer,
                                                     issuer,
                                                     permClaims,
                                                     expires: DateTime.Now.AddDays(1),
                                                     signingCredentials: credentials);
                    var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);
                    data = new
                    {
                        token= jwt_token,
                    };

                }
               

            }
            catch (Exception e)
            {
                data = new
                {
                    valid = false,
                };

            }
            return data;


        }
        //[HttpPost]
        //public String GetName1()
        //{
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        var identity = User.Identity as ClaimsIdentity;
        //        if (identity != null)
        //        {
        //            IEnumerable<Claim> claims = identity.Claims;
        //        }
        //        return "Valid";
        //    }
        //    else
        //    {
        //        return "Invalid";
        //    }
        //}

        //[Authorize]
        //[HttpPost]
        //public Object GetName2()
        //{
        //    var identity = User.Identity as ClaimsIdentity;
        //    if (identity != null)
        //    {
        //        IEnumerable<Claim> claims = identity.Claims;
        //        var name = claims.Where(p => p.Type == "name").FirstOrDefault()?.Value;
        //        return new
        //        {
        //            data = name
        //        };

        //    }

        //    return null;
        //}
    }
}
