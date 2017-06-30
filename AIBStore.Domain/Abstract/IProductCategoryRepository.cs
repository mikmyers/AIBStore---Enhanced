//---------------------------------------------------------------------
// <copyright file="IProductCategoryRepository.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
//     THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//     OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//     LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
//     FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
//---------------------------------------------------------------------
using System.Collections.Generic;
using AIBStore.Domain.Entities;
using System;

namespace AIBStore.Domain.Abstract
{
    public interface IProductCategoryRepository : IDisposable
    {
        IEnumerable<ProductCategory> GetProductCategories();
        void Insert(ProductCategory productCategory);
        void Update(ProductCategory productCategory);
        ProductCategory Delete(int ID);
        ProductCategory GetProductCategoryByID(int ID);

    }
}