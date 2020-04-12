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
