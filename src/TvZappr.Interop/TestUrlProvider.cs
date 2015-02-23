namespace TvZappr.Interop
{
    public class TestUrlProvider : IUrlProvider
    {
        public string WebServiceUrl
        {
            get { return "http://localhost:8888/"; }
        }
    }
}