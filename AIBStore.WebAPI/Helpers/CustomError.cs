//---------------------------------------------------------------------
// <copyright file="CustomError.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
//     THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//     OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//     LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
//     FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
//---------------------------------------------------------------------
using System;

using Elmah;

namespace AIBStore.WebAPI.Helpers
{
    public static class CustomError
    {
        public static void RaiseError(ErrorLevel level, string Message)
        {
            switch (level)
            {
                case ErrorLevel.Fatal:
                    Logger.FatalLog(Message);
                    break;
                case ErrorLevel.Error:
                    Logger.ErrorLog(Message);
                    break;
                case ErrorLevel.Info:
                    Logger.InfoLog(Message);
                    break;
                case ErrorLevel.Warning:
                    Logger.WarningLog(Message);
                    break;
            }

            Exception newEx = new Exception(Message);
            ErrorSignal.FromCurrentContext().Raise(newEx);
        }

        public static void HandleError(Exception ex)
        {
            Logger.ErrorLog(ex.Message.ToString());
            ErrorSignal.FromCurrentContext().Raise(ex);
        }

    }
    public enum ErrorLevel { Fatal, Error, Warning, Info };
}