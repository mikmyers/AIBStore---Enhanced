//---------------------------------------------------------------------
// <copyright file="UnitOfWork.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
//     THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//     OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//     LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
//     FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
//---------------------------------------------------------------------
using System;
using AIBStore.Domain.Entities;
using AIBStore.Domain.Abstract;

namespace AIBStore.Domain.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private EFDbContext context = new EFDbContext();
        private GenericRepository<Product> productRepository;
        private GenericRepository<ProductCategory> productCategoryRepository;
        private bool disposed = false;

        public GenericRepository<Product> ProductRepository()
        {

            if (this.productRepository == null)
            {
                this.productRepository = new GenericRepository<Product>(context);
            }
            return productRepository;
        }

        public GenericRepository<ProductCategory> ProductCategoryRepository()
        {

            if (this.productCategoryRepository == null)
            {
                this.productCategoryRepository = new GenericRepository<ProductCategory>(context);
            }
            return productCategoryRepository;
        }

        public void Save()
        {
            context.SaveChanges();
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
