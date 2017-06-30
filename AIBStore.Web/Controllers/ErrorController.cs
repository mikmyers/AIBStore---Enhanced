//---------------------------------------------------------------------
// <copyright file="ErrorController.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
//     THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//     OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//     LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
//     FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
//---------------------------------------------------------------------using System.Web.Mvc;
using System;
using System.Web.Mvc;

namespace AIBStore.MVC.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult GeneralError(Exception exception)
        {
            return View(exception);
        }
    }
}