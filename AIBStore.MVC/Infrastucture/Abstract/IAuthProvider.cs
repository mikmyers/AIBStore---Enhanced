//---------------------------------------------------------------------
// <copyright file="IAuthProvider.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
//     THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//     OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//     LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
//     FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
//---------------------------------------------------------------------

namespace AIBStore.MVC.Infrastucture.Abstract
{
    public interface IAuthProvider
    {
        bool Authenticate(string username, string password);
        void Logout();
    }
}
