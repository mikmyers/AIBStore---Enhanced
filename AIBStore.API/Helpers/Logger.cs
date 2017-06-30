//---------------------------------------------------------------------
// <copyright file="Logger.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
//     THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//     OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//     LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
//     FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
//---------------------------------------------------------------------

namespace AIBStore.WebAPI.Helpers
{
    public class Logger
    {
        private static readonly log4net.ILog log =
        log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void FatalLog(string message)
        {
            log.Fatal(message);
        }
        public static void ErrorLog(string message)
        {
            log.Error(message);
        }
        public static void WarningLog(string message)
        {
            log.Warn(message);
        }
        public static void InfoLog(string message)
        {
            log.Info(message);
        }
        public static void DebugLog(string message)
        {
            log.Debug(message);
        }
    }
}