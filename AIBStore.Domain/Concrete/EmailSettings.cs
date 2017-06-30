//---------------------------------------------------------------------
// <copyright file="EmailSettings.cs" company="Microsoft">
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

namespace AIBStore.Domain.Concrete
{
    public class EmailSettings
    {
        public bool UseSsl = true;
        public string Username = "MySmtpUsername";
        public string Password = "MySmtpPassword";
        public string ServerName = "smtp.example.com";
        public int ServerPort = 587;
        public bool WriteAsFile = true;
        public string FileLocation = @"c:\store_emails";
    }
}
