using UnityEngine;

public sealed class UdpServiceStub : IUdpService // отправка UDP
{
    public void Send(string command) 
    {
        Debug.Log($"<color=#00C853>[UDP]</color> Command sent: <b>{command}</b>");
    }
}