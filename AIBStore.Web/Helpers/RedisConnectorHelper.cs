//---------------------------------------------------------------------
// <copyright file="RedisConnectorHelper.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
//     THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//     OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//     LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
//     FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
//---------------------------------------------------------------------
using System;
using StackExchange.Redis;
using Newtonsoft.Json;
using AIBStore.Domain.Entities;
using System.Web;

namespace AIBStore.MVC.Helperss
{
    public class RedisConnectorHelper
    {
        static RedisConnectorHelper()
        {
            RedisConnectorHelper.lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect("localhost");
            });
        }

        private static Lazy<ConnectionMultiplexer> lazyConnection;

        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }

    }

    public class RedisUpdateHelper
    {
        public static void Update<T>(string key, T obj)
        {
            var cache = RedisConnectorHelper.Connection.GetDatabase();
            cache.StringSet(key, JsonConvert.SerializeObject(obj));
        }
    }
}