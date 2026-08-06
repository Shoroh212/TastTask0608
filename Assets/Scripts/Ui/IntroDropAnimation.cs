using DG.Tweening;
using UnityEngine;

public class IntroDropAnimation : MonoBehaviour
{
    [SerializeField] private float targetY = 0f;
    [SerializeField] private float fallDuration = 0.6f;
    [SerializeField] private float bounceHeight = 20f;
    [SerializeField] private float bounceDuration = 0.12f;

    private void Start()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(
            transform.DOMoveY(targetY, fallDuration)
                .SetEase(Ease.InQuad)
        );

        sequence.Append(
            transform.DOMoveY(targetY + bounceHeight, bounceDuration)
                .SetEase(Ease.OutQuad)
        );

        sequence.Append(
            transform.DOMoveY(targetY, bounceDuration)
                .SetEase(Ease.InQuad)
        );
    }
}