//---------------------------------------------------------------------
// <copyright file="TestController.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
//     THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//     OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//     LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
//     FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
//---------------------------------------------------------------------

using System;
using System.Web.Mvc;
using AIBStore.MVC.Helpers;

namespace AIBStore.MVC.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult DisplayError(bool display=true)
        {
            try
            {
                if (display) throw new Exception("this is an error");
                return View(display);
            }
            catch (Exception ex)
            {
                CustomError.HandleError(ex);
                return View("../Error/Error");
            }
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

    }
}