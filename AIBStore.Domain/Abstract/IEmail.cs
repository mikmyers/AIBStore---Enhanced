//---------------------------------------------------------------------
// <copyright file="IEmail.cs" company="Microsoft">
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
using AIBStore.Domain.Entities;

namespace AIBStore.Domain.Abstract
{
    public interface IEmailProcessor
    {
        void Send(Email email);
    }
}
