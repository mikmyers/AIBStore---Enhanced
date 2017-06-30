//---------------------------------------------------------------------
// <copyright file="EFProductRepository.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
//     THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//     OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//     LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
//     FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
//---------------------------------------------------------------------
using System;
using AIBStore.Domain.Abstract;
using AIBStore.Domain.Entities;
using System.Collections.Generic;

namespace AIBStore.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private EFDbContext context = new EFDbContext();
        private bool disposed = false;

        public IEnumerable<Product> GetProducts()
        {
            return context.Products;
        }

        public void Insert(Product product)
        {

            context.Products.Add(product);
            context.SaveChanges();
        }

        public void Update(Product product)
        {

            Product prod = context.Products.Find(product.ProductID);
            if (prod != null)
            { 
                prod = product;
                context.SaveChanges();
            }
        }

        public Product Delete(int ID)
        {
            Product prod = context.Products.Find(ID);
            if (prod != null)
            {
                context.Products.Remove(prod);
                context.SaveChanges();
            }
            return prod;
        }

        public Product GetProductByID(int ID)
        {
            Product prod = context.Products.Find(ID);
            return prod;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}