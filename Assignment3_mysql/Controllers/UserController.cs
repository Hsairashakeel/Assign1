using BAL_assign3;
using Entities_assign3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment3_mysql.Controllers
{
    public class UserController : Controller
    {
        // GET: User
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
                if (result == true)
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
        public JsonResult createFolder(String folderName, String UID, int pid)
        {
            object data = null;
            try
            {
                var flag = false;
                int uid = Int32.Parse(UID);
                bool isExisting = false;
                if (pid != 0)
                {
                    isExisting = FolderBO.IsExistingFolder(folderName, pid);
                }
                if (isExisting == false)
                {
                    int count = FolderBO.Save(folderName, pid, uid);
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
            catch (Exception e)
            {
                data = new
                {
                    valid = false,
                };
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult fetchFoldersData(String id, int pid)
        {

            object data = null;
            try
            {
                var flag = false;
                List<FolderDTO> dto = new List<FolderDTO>();
                int ID = Int32.Parse(id);
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

    }
}