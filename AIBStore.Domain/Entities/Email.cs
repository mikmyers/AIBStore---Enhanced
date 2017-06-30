//---------------------------------------------------------------------
// <copyright file="Email.cs" company="Microsoft">
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
using System.Runtime.Serialization;

namespace AIBStore.Domain.Entities
{

    //[DataContractAttribute]
    public class Email
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public Email()
        {
            To = string.Empty;
            From = string.Empty;
            Subject = string.Empty;
            Body = string.Empty;
        }
        public Email(string to, string from, string subject, string body)
        {
            To = to;
            From = from;
            Subject = subject;
            Body = body;
        }

    }
}
