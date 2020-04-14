// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http;

namespace Microsoft.AspNetCore.Server.IIS
{
    [Obsolete("Moved to Microsoft.AspNetCore.Http.BadHttpRequestException")]
    public sealed class BadHttpRequestException : Microsoft.AspNetCore.Http.BadHttpRequestException
    {
        internal BadHttpRequestException(string message, int statusCode, RequestRejectionReason reason)
            : base(message, statusCode)
        {
            Reason = reason;
        }

        public new int StatusCode { get => base.StatusCode; }

        internal RequestRejectionReason Reason { get; }
    }
}
