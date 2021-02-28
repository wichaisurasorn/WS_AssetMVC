using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WS_AssetMVC.Datas;
using WS_AssetMVC.Models;

namespace WS_AssetMVC.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        DataDB datauser = new DataDB();
        //Login User
        public IActionResult Loginuser(string username, string password)
        {
            List<EmpleyeGet> Luser = new List<EmpleyeGet>();
            var login = datauser.GetUser().FirstOrDefault(x => x.user_Username == username);
            try
            {
                if (login != null)
                {
                    return Json(new { redirectToUrl = Url.Action("Index", "Home") });
                    //return RedirectToAction("Index", "Home");

                }
                return Content("User ไม่ตรง");

            }
            catch (Exception ex)
            {
                return Content("Erro :" + ex.Message);
            }
        }

        [HttpPost]
        public JsonResult ValidateUser(string username, string password)
        {
            List<EmpleyeGet> Luser = new List<EmpleyeGet>();
            var login = datauser.GetUser().FirstOrDefault(x => x.user_Username == username);
            if (login != null)
            {
                return Json(new { IsSuccess = true,
                                    redirectToUrl = Url.Action("Index", "Home") });
            }
            else
            {
                return Json(new { IsSuccess = false,
                                    redirectToUrl = ""});
            }
        }
    }
}
