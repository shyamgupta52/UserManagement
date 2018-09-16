using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;
using System.Net.Http;

namespace MVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            IEnumerable<mvcUserModel> userlist;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Users").Result;
            userlist = response.Content.ReadAsAsync<IEnumerable<mvcUserModel>>().Result;
            return View(userlist);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if(id == 0)
            {
                return View(new mvcUserModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Users/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcUserModel>().Result);
            }
            
        }

        [HttpPost]
        public ActionResult AddorEdit(mvcUserModel usr)
        {
            if (usr.Id == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Users", usr).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }

            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Users/"+usr.Id, usr).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Users/"+id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Sucessfully";
            return RedirectToAction("Index");
        }

    }
}