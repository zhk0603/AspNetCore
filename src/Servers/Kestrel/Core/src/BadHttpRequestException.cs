// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Infrastructure;
using Microsoft.Extensions.Primitives;

namespace Microsoft.AspNetCore.Server.Kestrel.Core
{
    [Obsolete("Moved to Microsoft.AspNetCore.Http.BadHttpRequestException")]
    public sealed class BadHttpRequestException : Microsoft.AspNetCore.Http.BadHttpRequestException
    {
        internal BadHttpRequestException(string message, int statusCode, RequestRejectionReason reason)
            : this(message, statusCode, reason, null)
        { }

        internal BadHttpRequestException(string message, int statusCode, RequestRejectionReason reason, HttpMethod? requiredMethod)
            : base(message, statusCode)
        {
            Reason = reason;

            if (requiredMethod.HasValue)
            {
                AllowedHeader = HttpUtilities.MethodToString(requiredMethod.Value);
            }
        }

        public new int StatusCode { get => base.StatusCode; }

        internal StringValues AllowedHeader { get; }

        internal RequestRejectionReason Reason { get; }
    }
}
