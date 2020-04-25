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
    public class folderDTO
    {
        public string folderName { set; get; }
        public int pid { set; get; }


    }
    public class userDTO
    {
        public string name { set; get; }
        public string passw { set; get; }
        public string email { set; get; }

    }
    [EnableCors(origins: "https://localhost:44384", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
       
        [HttpPost]
        public Object createFolder(folderDTO dto)
        {
            object data = null;
            try
            {
                var identity = User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    IEnumerable<Claim> claims = identity.Claims;
                    var id = claims.Where(p => p.Type == "userid").FirstOrDefault()?.Value;
                    int ID = Int32.Parse(id);
                    var flag = false;
                    bool isExisting = false;
                    if (dto.pid != 0)
                    {
                        isExisting = FolderBO.IsExistingFolder(dto.folderName, dto.pid);
                    }
                    if (isExisting == false)
                    {
                        int count = FolderBO.Save(dto.folderName, dto.pid, ID);
                        if (count > 0)
                        {
                            flag = true;
                            data = new
                            {
                                valid = flag,
                            };
                        }
                    }
                    else
                    {
                        data = new
                        {
                            valid = false,
                        };
                    }
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

        [HttpGet]
        public Object validateUser(String name, String passw,String grant_type)
        {
            object data = null;
            try
            {

                bool result = UserBO.IsValidUser(name, passw);
                if (result == true)
                {
                    var dto = new UserDTO();
                    dto = UserBO.GetUserDataByLogin(name);
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
                        token = jwt_token,
                        userObj = dto,
                        valid = true
                    };

                }
                else
                {
                    data = new
                    {
                        valid = false
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
        

        [HttpGet]
        public Object fetchFoldersData( int pid)
        {

            object data = null;
            try
            {
                var identity = User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    IEnumerable<Claim> claims = identity.Claims;
                    var id = claims.Where(p => p.Type == "userid").FirstOrDefault()?.Value;
                    int ID = Int32.Parse(id);
                    var flag = false;
                    List<FolderDTO> dto = new List<FolderDTO>();
                    dto = FolderBO.GetFolderNames(ID, pid);
                    List<String> list = new List<String>();
                    if (dto != null)
                    {

                        flag = true;
                        data = new
                        {
                            valid = flag,
                            list = dto
                        };
                    }
                }

            }
            catch (Exception e)
            {
                data = new
                {
                    valid = false,
                    list = ""

                };
            }
            return data;
        }
        [HttpPost]
        public Object InsertUser(userDTO obj)
        {
            object data = null;
            try
            {
                UserDTO dto = new UserDTO();
                dto.Login = obj.name;
                dto.password = obj.passw;
                dto.email = obj.email;
                var flag = false;
                bool isExLogin = UserBO.IsExistingLogin(obj.name);
                bool isExEmail = UserBO.IsExistingEmail(obj.email);
                if (isExEmail == false && isExLogin == false)
                {
                    int result = UserBO.Save(dto);
                    if (result > 0)
                    {
                        flag = true;
                    }
                    data = new
                    {
                        valid = flag,

                    };
                }
                else
                {
                    data = new
                    {
                        valid = false,
                    };
                }
            }
            catch (Exception e)
            {
                data = new
                {
                    valid = false,
                    urlToRedirect = ""

                };
            }
            return data;
        }
       
    }
    
}
