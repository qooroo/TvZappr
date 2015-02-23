using System.Diagnostics;
using System.Threading;
using FluentAssertions;
using TvZappr.Interop;
using Xunit;

namespace TvZappr.Tests
{
    public class ServiceSmokeTests
    {
        private readonly HttpServiceClient _httpClient;
        private const string ServiceExe = @"..\..\..\TvZAppr.Web\bin\Debug\TvZappr.Web.exe";

        public ServiceSmokeTests()
        {
            _httpClient = new HttpServiceClient(new TestUrlProvider());
        }

        [Fact]
        public void GivenServiceRunning_ThenPingControllerRespondsOk()
        {
            Process svc = null;
            try
            {
                svc = Process.Start(ServiceExe);
                Thread.Sleep(1000);
                _httpClient.GetAsync<string>(ApiRoutes.Ping).Result.Should().Be("pong!");
            }
            finally
            {
                if (svc != null)
                {
                    svc.Kill();
                }
            }
        }
    }
}
