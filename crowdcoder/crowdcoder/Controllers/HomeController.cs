using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using testMVC.Models;
using crowdcoderDTO;
using DataAccess;
namespace testMVC.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            ViewBag.login=Request.Cookies["login"];

            return View();
        }

        public IActionResult register(string login, string password){

            if(login!=null && login.Count()>0 && password!=null && password.Count()>0){

                User user=new SqlServerAccess().GetUserId(login, password);
                CookieOptions cookie=new CookieOptions();
                cookie.Expires=DateTime.Now.AddSeconds(1200);


                Response.Cookies.Append("login",user.login,cookie);
                ViewBag.login=login;

                return Redirect("/");
            }
            else{

                return Redirect("/");
            }
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
