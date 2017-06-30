//---------------------------------------------------------------------
// <copyright file="EFDbExecutionStrategy.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
//     THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//     OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//     LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
//     FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
//---------------------------------------------------------------------
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;
using System;
using System.Linq;

namespace AIBStore.Domain.Concrete
{
    public class EFDbExecutionStrategy : DbExecutionStrategy
    {
        public EFDbExecutionStrategy(int maxRetryCount, TimeSpan maxDelay) : base()
        {
        }
        protected override bool ShouldRetryOn(Exception ex)
        {
            bool retry = false;

            SqlException sqlException = ex as SqlException;
            if (sqlException != null)
            {
                int[] errorsToRetry =
                {
                    1205,  //Deadlock
                    -2    //Timeout
                };
                if (sqlException.Errors.Cast<SqlError>().Any(x => errorsToRetry.Contains(x.Number)))
                {
                    retry = true;
                }
                else
                {
                    //Add some error logging on this line for errors we aren't retrying.
                    //Make sure you record the Number property of sqlError. 
                    //If you see an error pop up that you want to retry, you can look in 
                    //your log and add that number to the list above.
                    throw (ex);
                }
            }
            if (ex is TimeoutException)
            {
                retry = true;
            }
            return retry;
        }
    }
}
