using Ruffles.Connections;
using System;
using System.Net;
using System.Threading;

namespace Ruffles.Core
{
    public interface IRuffleSocket
    {
        bool IsInitialized { get; }
        bool IsRunning { get; }
        IPEndPoint LocalIPv4EndPoint { get; }
        IPEndPoint LocalIPv6EndPoint { get; }
        AutoResetEvent SyncronizationEvent { get; }

        Connection Connect(IPEndPoint endpoint);
        NetworkEvent Poll();
        void RegisterSyncronizedCallback(SendOrPostCallback callback, SynchronizationContext syncContext = null);
        bool SendBroadcast(ArraySegment<byte> payload, int port);
        bool SendUnconnected(ArraySegment<byte> payload, IPEndPoint endpoint);
        void Shutdown();
        bool Start();
        void Stop();
        void UnregisterSyncronizedCallback(SendOrPostCallback callback);
    }
}