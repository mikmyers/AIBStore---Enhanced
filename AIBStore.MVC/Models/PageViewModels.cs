//---------------------------------------------------------------------
// <copyright file="PageiewModel.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
//     THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//     OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//     LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
//     FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
//---------------------------------------------------------------------
using System;


namespace AIBStore.MVC.Models
{
    public class PageInfo
    {
        public int CurrentPage { get; set; }
        public int TotalNoItems { get; set; }
        public int ItemsOnPage { get; set; }

        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalNoItems / ItemsOnPage); }
        }
    }
}