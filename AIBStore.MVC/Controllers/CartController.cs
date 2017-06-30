//---------------------------------------------------------------------
// <copyright file="CartController.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
//     THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//     OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//     LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
//     FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
//---------------------------------------------------------------------using System.Web.Mvc;
using System;
using System.Linq;
using System.Web.Mvc;
using AIBStore.Domain.Abstract;
using AIBStore.Domain.Entities;
using AIBStore.MVC.Models;
using System.Net.Http;
using System.Threading.Tasks;
using System.Configuration;
using AIBStore.MVC.Helpers;

namespace AIBStore.MVC.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository productRepository;
        private IOrderProcessor orderProcessor;
        private IEmailProcessor emailProcessor;
        private HttpClient apiClient;

        public CartController(IProductRepository prodRepository, IOrderProcessor orderProcessor, IEmailProcessor emailProcessor)
        {
            this.productRepository = prodRepository;
            this.orderProcessor = orderProcessor;
            this.emailProcessor = emailProcessor;
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl)
        {
            Product product = productRepository.GetProducts()
                .FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                cart.AddItem(HttpContext.Session[Constants.Constants.SessionCacheKey].ToString(), product, 1);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl)
        {
            Product product = productRepository.GetProducts()
                .FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                cart.RemoveLine(HttpContext.Session[Constants.Constants.SessionCacheKey].ToString(), product);
            }

            return RedirectToAction("Index", new { returnUrl });
        }
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public async Task<ViewResult> Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            try
            {
                if (cart.Lines.Count() == 0)
                {
                    ModelState.AddModelError("", Resource.EMPTY_CART);
                }

                if (ModelState.IsValid)
                {
                    string apiUrl = String.Concat(ConfigurationManager.AppSettings["APIUrl"], "email");
                    apiClient = new HttpClient();
                    apiClient.BaseAddress = new Uri(apiUrl);
                    apiClient.DefaultRequestHeaders.Accept.Clear();
                    apiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    string body = orderProcessor.ProcessOrder(cart, shippingDetails);
                    Email email = new Email();
                    email.To = shippingDetails.EMail;
                    email.From = Resource.EMAIL_FROM;
                    email.Subject = Resource.EMAIL_SUBJECT;
                    email.Body = body;

                    HttpResponseMessage responseMessage = await apiClient.PostAsJsonAsync(apiUrl, email);

                    if (responseMessage.IsSuccessStatusCode)
                    {
                        cart.Clear();
                        return View("Completed");
                    }
                    else
                    {
                        CustomError.RaiseError(ErrorLevel.Error, responseMessage.ToString());
                        return View("Error");
                    }
                }
                else
                {
                    return View(shippingDetails);
                }
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