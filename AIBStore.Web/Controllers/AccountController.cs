//---------------------------------------------------------------------
// <copyright file="AccountController.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
//     THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//     OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//     LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
//     FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
//---------------------------------------------------------------------
using System.Web.Mvc;
using AIBStore.MVC.Infrastucture.Abstract;
using AIBStore.MVC.Models;
using AIBStore.Cache;

namespace AIBStore.MVC.Controllers
{
    public class AccountController : Controller
    {
        IAuthProvider authProvider;

        public AccountController(IAuthProvider aProvider)
        {
            authProvider = aProvider;
        }

        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {

            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(model.UserName, model.Password))
                {
                    RedisUpdateHelper.Update(string.Concat(HttpContext.Session[Constants.Constants.SessionCacheKey].ToString(), Constants.Constants.UsernameCacheKey), model.UserName);
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin", model));
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
        public ActionResult Logout(string returnUrl)
        {
            authProvider.Logout();
            RedisUpdateHelper.Update(string.Concat(HttpContext.Session[Constants.Constants.SessionCacheKey].ToString(), Constants.Constants.UsernameCacheKey), string.Empty);
            return Redirect(returnUrl ?? Url.Action("List", "Product"));
        }
    }
}