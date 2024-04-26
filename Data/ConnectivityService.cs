using System;
using Microsoft.Maui.Networking;

public class ConnectivityService
{
    public event Action<bool> ConnectivityChanged;

    public ConnectivityService()
    {
        Connectivity.Current.ConnectivityChanged += OnConnectivityChanged;
    }

    private void OnConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
    {
        ConnectivityChanged?.Invoke(e.NetworkAccess == NetworkAccess.Internet);
    }

    public bool IsConnected => Connectivity.Current.NetworkAccess == NetworkAccess.Internet;
}