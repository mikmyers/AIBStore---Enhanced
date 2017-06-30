//---------------------------------------------------------------------
// <copyright file="OrderProcessor.cs" company="Microsoft">
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
using System.Text;
using System.Threading.Tasks;
using AIBStore.Domain.Abstract;
using AIBStore.Domain.Entities;
using System.Net;
using System.Net.Mail;

namespace AIBStore.Domain.Concrete
{
       
    public class OrderProcessor : IOrderProcessor
    {
        public string ProcessOrder(Cart cart, ShippingDetails shippingInfo)
        {
            StringBuilder body = new StringBuilder()
                .AppendLine("A new order has been submitted")
                .AppendLine("---")
                .AppendLine("Items:");

            foreach (var line in cart.Lines)
            {
                var subtotal = line.Product.Price * line.Quantity;
                body.AppendFormat("{0} x {1} (subtotal: {2:c}", line.Quantity,
                                    line.Product.Name,
                                    subtotal);
            }

            body.AppendFormat("Total order value: {0:c}", cart.ComputeTotalValue())
                .AppendLine("---")
                .AppendLine("Ship to:")
                .AppendLine(shippingInfo.Name)
                .AppendLine(shippingInfo.Line1)
                .AppendLine(shippingInfo.Line2 ?? "")
                .AppendLine(shippingInfo.Line3 ?? "")
                .AppendLine(shippingInfo.City)
                .AppendLine(shippingInfo.County ?? "")
                .AppendLine(shippingInfo.Country)
                .AppendLine("---")
                .AppendFormat("Gift wrap: {0}", shippingInfo.GiftWrap ? "Yes" : "No");

            return (body.ToString());
        }
    }

}
