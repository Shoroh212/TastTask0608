using DG.Tweening;
using UnityEngine;
using Zenject;
using static UnityEngine.Rendering.DebugUI;

public class OpenInformationPanel : MonoBehaviour
{
    [Inject]
    private SignalBus _signalBus;
    [SerializeField] private RectTransform panel;
    [SerializeField] private float moveDistance = 500f;
    [SerializeField] private float duration = 0.5f;


    private void OnEnable()
    {
        _signalBus.Subscribe<CardSelectedSignal>(OpenPanel);
    }

    private void OnDisable()
    {
        _signalBus.Unsubscribe<CardSelectedSignal>(OpenPanel);
    }

    private void OpenPanel()
    {
        panel.DOAnchorPosX(
            panel.anchoredPosition.x + moveDistance,
            duration)
            .SetEase(Ease.OutBack);
    }

    public void ClosePanel()
    {
        panel.DOAnchorPosX(
            panel.anchoredPosition.x - moveDistance,
            duration)
            .SetEase(Ease.InBack);
    }
}