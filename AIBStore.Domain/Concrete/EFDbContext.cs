﻿//---------------------------------------------------------------------
// <copyright file="EFDbContext.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
//     THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//     OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//     LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
//     FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
//---------------------------------------------------------------------
using AIBStore.Domain.Entities;
using System.Data.Entity;

namespace AIBStore.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
    }
}
