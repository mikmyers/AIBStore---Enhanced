//---------------------------------------------------------------------
// <copyright file="IOrderProcessor.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
//     THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//     OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//     LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
//     FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
//---------------------------------------------------------------------
using AIBStore.Domain.Entities;

namespace AIBStore.Domain.Abstract
{
    public interface IOrderProcessor
    {
        string ProcessOrder(Cart cart, ShippingDetails shippingDetails);
    }
}
