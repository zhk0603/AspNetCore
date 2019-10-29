using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;
using Xunit;

namespace Microsoft.AspNetCore.Server.Kestrel.Core.Tests
{
    public class Http3StreamTests : Http3TestBase
    {
        [Fact]
        public async Task HEADERS_Received_EmptyMethod_Reset()
        {
            var headers = new[]
            {
                new KeyValuePair<string, string>(HeaderNames.Method, "Custom"),
                new KeyValuePair<string, string>(HeaderNames.Path, "/"),
                new KeyValuePair<string, string>(HeaderNames.Scheme, "http"),
                new KeyValuePair<string, string>(HeaderNames.Authority, "localhost:80"),
            };

            await InitializeConnectionAsync(_echoApplication);

            var controlStream1 = await CreateControlStream(0);
            var controlStream2 = await CreateControlStream(2);
            var controlStream3 = await CreateControlStream(3);

            var requestStream = await CreateRequestStream();
            var doneWithHeaders = await requestStream.SendHeadersAsync(headers);
            await requestStream.SendDataAsync(Encoding.ASCII.GetBytes("Hello world"));

            var responseHeaders = await requestStream.ExpectHeadersAsync();
            var responseData = await requestStream.ExpectDataAsync();
            Assert.Equal("Hello world", Encoding.ASCII.GetString(responseData.ToArray()));
        }
    }
}
