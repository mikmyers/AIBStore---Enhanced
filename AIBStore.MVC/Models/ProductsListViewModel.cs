
//---------------------------------------------------------------------
// <copyright file="ProductListVieuwModel.cs" company="Microsoft">
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
using AIBStore.Domain.Entities;
using AIBStore.MVC.Models;

namespace AIBStore.MVC.Models
{
    public class ProductsListViewModel
    {

        public IEnumerable<Product> Products { get; set; }
        public PageInfo PageInfo { get; set; }
        public string CurrCategory { get; set; }
    }
}