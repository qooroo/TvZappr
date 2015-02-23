using System.Reflection;
using log4net;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Infrastructure;

namespace TvZappr.Web.SignalR
{
    public class Broadcaster : IBroadcaster
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IHubContext _context;

        public Broadcaster(IConnectionManager connectionManager)
        {
            _context = connectionManager.GetHubContext<BroadcastHub>();
        }
        public void BroadcastMessage(string message)
        {
            Logger.InfoFormat("Broadcasting message: {0}", message);
            _context.Clients.All.OnMessage(message);
        }
    }
}