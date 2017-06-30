//---------------------------------------------------------------------
// <copyright file="MenuController.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
//     THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//     OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//     LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
//     FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
//---------------------------------------------------------------------using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AIBStore.Domain.Abstract;
using AIBStore.Domain.Concrete;

namespace AIBStore.MVC.Controllers
{
    public class MenuController : Controller
    {
        private IUnitOfWork unitOfWork;

        public MenuController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public PartialViewResult Menu(string category = null)
        {

            ViewBag.SelectedCategoryName= category;

            IEnumerable<string> categories = unitOfWork.ProductRepository().Get()
                                    .Select(x => x.ProductCategory.Name)
                                    .Distinct()
                                    .OrderBy(x => x);

            return PartialView(categories);
        }
        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}