//---------------------------------------------------------------------
// <copyright file="AdminController.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
//     THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//     OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//     LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
//     FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
//---------------------------------------------------------------------
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AIBStore.Domain.Abstract;
using AIBStore.Domain.Entities;
using AIBStore.MVC.Helpers;
using AIBStore.MVC.Models;
using AIBStore.Domain.Concrete;
using AIBStore.Cache;

namespace AIBStore.MVC.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IUnitOfWork unitOfWork;

        public AdminController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public ViewResult Index(LoginViewModel model)
        {
            try
            {
                string key = string.Concat(HttpContext.Session[Constants.Constants.SessionCacheKey], Constants.Constants.UsernameCacheKey);
                string userName = RedisUpdateHelper.Get<string>((string)(key));
                ViewBag.UserName = userName;
                return View(unitOfWork.ProductRepository().Get());
            }
            catch(Exception ex)
            {
                CustomError.HandleError(ex);
                return View("../Error/Error");
            }
        }

        public ViewResult Edit(int productId)
        {
            try
            {
                Product product = unitOfWork.ProductRepository().Get().FirstOrDefault(p => p.ProductID == productId);
                PopulateCategoryDropDownList(product.ProductCategory.ProductCategoryID);
                return View(product);
            }
            catch(Exception ex)
            {
                CustomError.HandleError(ex);
                return View("../Error/Error");
            }
        }

        [HttpPost]
        public ActionResult Edit(Product product, HttpPostedFileBase image = null)
        {
            try
            { 
                if (ModelState.IsValid)
                {
                    if (image != null)
                    {
                        product.ImageMimeType = image.ContentType;
                        product.ImageData = new byte[image.ContentLength];
                        image.InputStream.Read(product.ImageData, 0, image.ContentLength);
                    }
                    if (product.ProductID == 0)
                        unitOfWork.ProductRepository().Insert(product);
                    else
                        unitOfWork.ProductRepository().Update(product);
                    unitOfWork.Save();

                    TempData["message"] = string.Format("{0} has been saved", product.Name);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(product);
                }
            }
            catch(Exception ex)
            {
                CustomError.HandleError(ex);
                return View("../Error/Error");
            }
        }

        public ViewResult Create()
        {
            PopulateCategoryDropDownList();
            return View("Edit", new Product());
        }

        [HttpPost]
        public ActionResult Delete(int productId)
        {
            Product deletedProduct = unitOfWork.ProductRepository().Delete(productId);
            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("{0} was deleted",
                    deletedProduct.Name);
            }
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }

        private void PopulateCategoryDropDownList(object selectedCategory = null)
        {
            var query = unitOfWork.ProductCategoryRepository().Get().OrderBy(x => x.Name);
            ViewBag.ProductCategoryID = new SelectList(query, "ProductCategoryID", "Name", selectedCategory);
        }
    }
}