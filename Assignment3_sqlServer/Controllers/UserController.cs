using BAL_assign3;
using Entities_assign3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment3_sqlServer.Controllers
{
    public class UserController : Controller
    {
        
        public ActionResult Login()
        {

            return View();
        }
        public ActionResult SignIn()
        {
            return View();
        }
        
        public ActionResult Home()
        {
            if (Session["login"] == null)
            {
                return Redirect("Login");
            }
            else
                return View();


        }
        public JsonResult fetchFoldersData(String id)
        {

            object data = null;
            try
            {
                var flag = false;
                List<String> names = new List<String>();
                int ID = Int32.Parse(id);
                names = FolderBO.GetFolderNamesWithParentNull(ID);
                List<String> list = new List<String>();
                if(names!=null)
                {
                    
                    flag = true;
                    data = new
                    {
                        valid = flag,
                        list = names
                    };
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
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult validateUser(String name, String passw)
        {
           
            object data = null;
            try
            {
                var url = "";
                var flag = false;
                bool result = UserBO.IsValidUser(name, passw);
                if(result==true)
                {
                    var dto = new UserDTO();
                    dto = UserBO.GetUserDataByLogin(name);
                    Session["id"] = dto.UserID;
                    Session["login"] = true;
                    flag = true;
                    url = "/User/Home";
                }
                data = new
                {
                    valid = flag,
                    urlToRedirect = url

                };

            }
            catch(Exception e)
            {
                data = new
                {
                    valid = false,
                    urlToRedirect = ""

                };
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult InsertUser(String name, String passw, String email)
        {
            object data = null;
            try
            {
                UserDTO dto = new UserDTO();
                dto.Login = name;
                dto.password = passw;
                dto.email = email;
                var url = "";
                var flag = false;
                bool isExLogin = UserBO.IsExistingLogin(name);
                bool isExEmail = UserBO.IsExistingEmail(email);
                if (isExEmail == false && isExLogin == false)
                {
                    int result = UserBO.Save(dto);
                    if (result > 0)
                    {
                        flag = true;
                        url = "/User/Login";
                    }
                    data = new
                    {
                        valid = flag,
                        urlToRedirect = url

                    };
                }
                else
                {
                    data = new
                    {
                        valid = false,
                        urlToRedirect = ""

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
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
    
}
