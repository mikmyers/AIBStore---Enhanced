﻿//---------------------------------------------------------------------
// <copyright file="RouteConfig.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
//     THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//     OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//     LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
//     FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
//---------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AIBStore.MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute
            (
               null,
               "",
               new
               {
                   Controller = "Product",
                   action = "List",
                   category = (string)null,
                   page = 1
               }
            );

            routes.MapRoute
            (
                null,
                "Page{page}",
                new
                {
                    controller = "Product", action = "List", category = (string)null
                },
                new
                {
                    page =  @"\d+" 
                }
            );

            routes.MapRoute
            (
                null,
                "{category}",
                new
                {
                    controller = "Product",
                    action = "List",
                    page = 1
                }

            );

            routes.MapRoute
            (
                null,
                "{category}/Page{page}",
                new
                {
                    controller = "Product",
                    action = "List",
                },
                new
                {
                    page = @"\d+"
                }
            );
            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}