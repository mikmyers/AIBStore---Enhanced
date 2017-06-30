//---------------------------------------------------------------------
// <copyright file="CartModelBinder.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
//     THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//     OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//     LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
//     FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
//---------------------------------------------------------------------

using System.Web.Mvc;
using AIBStore.Domain.Entities;
using AIBStore.Cache;
using Microsoft.AspNet.Identity;
using AIBStore.Constants;

namespace AIBStore.MVC.Infrastucture.Binders
{
    public class CartModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Cart cart = null;
            string key = string.Concat(controllerContext.HttpContext.Session[Constants.Constants.SessionCacheKey], Constants.Constants.CartCacheKey);

            var cache = RedisConnectorHelper.Connection.GetDatabase();
            if (cache.KeyExists(key))
            {
                cart = RedisUpdateHelper.Get<Cart>((string)(key));
            }

            if (cart == null)
            {
                cart = new Cart();
                if (!cache.KeyExists(string.Concat(controllerContext.HttpContext.Session[Constants.Constants.SessionCacheKey], key)))
                {
                    RedisUpdateHelper.Update(key, cart);
                }
            }
            return cart;
        }
    }
}