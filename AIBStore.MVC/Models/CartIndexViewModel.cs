//---------------------------------------------------------------------
// <copyright file="CartIndexViewModel.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
//     THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//     OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//     LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
//     FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
//---------------------------------------------------------------------
using AIBStore.Domain.Entities;

namespace AIBStore.MVC.Models
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}