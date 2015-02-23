namespace TvZappr.Web.SignalR
{
    public interface IBroadcaster
    {
        void BroadcastMessage(string message);
    }
}