//---------------------------------------------------------------------
// <copyright file="EFDbConfiguration.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
//     THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//     OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//     LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
//     FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
//---------------------------------------------------------------------
using System.Data.Entity;
using System;
using System.Configuration;

namespace AIBStore.Domain.Concrete
{
    public class EFDbConfiguration : DbConfiguration
    {
        EFDbConfiguration()
        {
            int maxRetryCount = 0;
            int maxDelay = 0;
            try { maxRetryCount = Convert.ToInt16(ConfigurationManager.AppSettings["DBFaultHandlingRetryCount"]);}
            catch(Exception) {maxRetryCount = 3;}
            try { maxDelay = Convert.ToInt16(ConfigurationManager.AppSettings["DBFaultHandlingMaxdelay"]);}
            catch (Exception) { maxDelay = 8;}
            SetExecutionStrategy("System.Data.SqlClient", () => new EFDbExecutionStrategy(maxRetryCount, TimeSpan.FromSeconds(maxDelay)));
        }
    }
}
