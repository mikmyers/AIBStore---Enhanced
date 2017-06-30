//---------------------------------------------------------------------
// <copyright file="ProductCategory.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
//     THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//     OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//     LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
//     FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
//---------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AIBStore.Domain.Entities
{
    public class ProductCategory
    {
        [HiddenInput(DisplayValue = false)]
        public int ProductCategoryID { get; set; }
        [Required(ErrorMessage = "Please enter a category name")]
        public string Name { get; set; }

    }
}
