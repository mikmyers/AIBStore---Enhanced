//---------------------------------------------------------------------
// <copyright file="Cart.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
//     THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//     OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//     LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
//     FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
//---------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using AIBStore.Cache;
using AIBStore.Constants;

namespace AIBStore.Domain.Entities
{

    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(string key, Product product, int quantity)
        {
            CartLine line = lineCollection
                .Where(p => p.Product.ProductID == product.ProductID)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
            RedisUpdateHelper.Update(string.Concat(key, Constants.Constants.CartCacheKey), this);
        }

        public void RemoveLine(string key, Product product)
        {
            lineCollection.RemoveAll(l => l.Product.ProductID == product.ProductID);
            RedisUpdateHelper.Update(string.Concat(key, Constants.Constants.CartCacheKey), this);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Product.Price * e.Quantity);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }
}
