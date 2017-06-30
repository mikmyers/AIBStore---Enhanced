//---------------------------------------------------------------------
// <copyright file="ProductController.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
//     THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//     OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//     LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
//     FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
//---------------------------------------------------------------------using System.Web.Mvc;
using System.Linq;
using System.Web.Mvc;
using AIBStore.Domain.Abstract;
using AIBStore.Domain.Concrete;
using AIBStore.MVC.Models;
using AIBStore.Domain.Entities;
using System;
using AIBStore.MVC.Helpers;
using System.Configuration;

namespace AIBStore.MVC.Controllers
{
    public class ProductController : Controller
    {
        public int PageSize = 4;
        private IUnitOfWork unitOfWork;

        public ProductController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            try { PageSize = Convert.ToInt16(ConfigurationManager.AppSettings["PageSize"]); }
            catch (Exception) { PageSize = 4; }
        }

        public ViewResult List(string category, int pageNo = 1)
        {
            try
            {
                ProductsListViewModel model = new ProductsListViewModel
                {
                    Products = unitOfWork.ProductRepository().Get()
                    .Where(p => category == null || p.ProductCategory.Name.ToUpper() == category.ToUpper())
                    .OrderBy(p => p.ProductID)
                    .Skip((pageNo - 1) * PageSize)
                    .Take(PageSize),
                    PageInfo = new PageInfo
                    {
                        CurrentPage = pageNo,
                        ItemsOnPage = PageSize,
                        TotalNoItems = category == null ?
                            unitOfWork.ProductRepository().Get().Count() :
                            unitOfWork.ProductRepository().Get().Where(e => e.ProductCategory.Name == category).Count()
                    },
                    CurrCategory = category
                };
                return View(model);
            }
            catch(Exception ex)
            {
                CustomError.HandleError(ex);
                return View("../Error/Error");
            }
        }

        public FileContentResult GetImage(int productId)
        {
            Product prod = unitOfWork.ProductRepository().Get()
                .FirstOrDefault(p => p.ProductID == productId);
            if (prod != null)
            {
                return File(prod.ImageData, prod.ImageMimeType);
            }
            else
            {
                return null;
            }
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }

    }
}