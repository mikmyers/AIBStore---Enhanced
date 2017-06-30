//---------------------------------------------------------------------
// <copyright file="IProductRepository.cs" company="Microsoft">
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
    public interface IProductRepository : IDisposable
    {
        IEnumerable<Product> GetProducts();
        void Insert(Product product);
        void Update(Product product);
        Product Delete(int ID);
        Product GetProductByID(int ID);

    }
}