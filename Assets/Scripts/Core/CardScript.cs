using UnityEngine;
using Zenject;
using System;
public class CardScript : MonoBehaviour
{
    [SerializeField] private Information _dataSO;

    private SignalBus _signalBus;
    private ICardReceiver _receiver;





    [Inject]
    public void Construct(
        SignalBus signalBus,
        ICardReceiver receiver)
    {
        _signalBus = signalBus;
        _receiver = receiver;
    }

    public void OnClickCard()
    {
        _receiver.Receive(_dataSO);

        _signalBus.Fire<CardSelectedSignal>();

    }
}
public interface ICardReceiver
{
    void Receive(Information information);
}
public interface ICardSender
{
    event Action OnCardSelected;
}

public interface IUdpService
{
    void Send(string command);
}