//---------------------------------------------------------------------
// <copyright file="EFProductCategoryRepository.cs" company="Microsoft">
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
    public class EFProductCategoryRepository : IProductCategoryRepository
    {
        private EFDbContext context = new EFDbContext();
        private bool disposed = false;

        public IEnumerable<ProductCategory> GetProductCategories()
        {
            return context.ProductCategories;
        }

        public void Insert(ProductCategory productCategory)
        {

            context.ProductCategories.Add(productCategory);
            context.SaveChanges();
        }

        public void Update(ProductCategory productCategory)
        {

            ProductCategory pc = context.ProductCategories.Find(productCategory.ProductCategoryID);
            if (pc != null)
            { 
                pc = productCategory;
                context.SaveChanges();
            }
        }

        public ProductCategory Delete(int ID)
        {
            ProductCategory p = context.ProductCategories.Find(ID);
            if (p != null)
            {
                context.ProductCategories.Remove(p);
                context.SaveChanges();
            }
            return p;
        }

        public ProductCategory GetProductCategoryByID(int ID)
        {
            return (context.ProductCategories.Find(ID));
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