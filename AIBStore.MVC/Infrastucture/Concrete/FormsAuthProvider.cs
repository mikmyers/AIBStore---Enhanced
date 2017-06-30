//---------------------------------------------------------------------
// <copyright file="FormsAuthProvider.cs" company="Microsoft">
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
using System.Web;
using AIBStore.MVC.Infrastucture.Abstract;
using System.Web.Security;

namespace AIBStore.MVC.Infrastucture.Concrete
{
    public class FormsAuthProvider : IAuthProvider
    {
        public bool Authenticate(string username, string password)
        {

            bool result = FormsAuthentication.Authenticate(username, password);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(username, false);
            }
            return result;
        }
        public void Logout()
        {
            FormsAuthentication.SignOut();
        }
    }
}