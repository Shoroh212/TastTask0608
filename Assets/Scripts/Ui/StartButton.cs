using DG.Tweening;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    [SerializeField] private GameObject _startText;
    [SerializeField] private GameObject _introPanel;

    [SerializeField] private GameObject _firstCard;
    [SerializeField] private GameObject _secondCard;
    [SerializeField] private GameObject _thirdCard;

    [Header("Intro Panel")]
    [SerializeField] private float targetY = 0f;
    [SerializeField] private float fallDuration = 0.6f;
    [SerializeField] private float bounceHeight = 20f;
    [SerializeField] private float bounceDuration = 0.12f;

    [Header("Cards Animation")]
    [SerializeField] private float cardScale = 0.172881f;
    [SerializeField] private float cardScaleDuration = 0.18f;
    [SerializeField] private float cardRotateAngle = 6f;
    [SerializeField] private float cardRotateDuration = 0.12f;



   [SerializeField] UdpServiceStub _service;  // Небольшое нарушение DIP,  но считаю для демонстрации это допустимо. В реальном проекте лучше использовать интерфейс IUdpService.

    public void OnClick()
    {
        _startText.SetActive(false);

        Sequence sequence = DOTween.Sequence();

        sequence.Append(
            _introPanel.transform.DOMoveY(targetY, fallDuration)
                .SetEase(Ease.InQuad));


        sequence.Append(
            _introPanel.transform.DOMoveY(targetY + bounceHeight, bounceDuration)
                .SetEase(Ease.OutQuad));

        sequence.Append(
            _introPanel.transform.DOMoveY(targetY, bounceDuration)
                .SetEase(Ease.InQuad));

        sequence.OnComplete(AnimateCards);

        _service.Send("Start");
    }

    private void AnimateCards()
    {
        AnimateCard(_firstCard);
        AnimateCard(_secondCard);
        AnimateCard(_thirdCard);
    }

    private void AnimateCard(GameObject card)
    {


        card.SetActive(true);

        Transform tr = card.transform;
        Vector3 originalScale = tr.localScale;


        Sequence sequence = DOTween.Sequence();

        sequence.Append(
            tr.DOScale(originalScale * cardScale, cardScaleDuration)
                .SetEase(Ease.OutBack));

        sequence.Append(
            tr.DOScale(originalScale, cardScaleDuration)
                .SetEase(Ease.InOutQuad));

        sequence.Append(
            tr.DORotate(new Vector3(0, 0, cardRotateAngle), cardRotateDuration));

        sequence.Append(
            tr.DORotate(new Vector3(0, 0, -cardRotateAngle), cardRotateDuration));

        sequence.Append(
            tr.DORotate(Vector3.zero, cardRotateDuration));
    }
}