using DG.Tweening;
using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextBlinkAnimation : MonoBehaviour
{
    [SerializeField] private float delay = 3f;
    [SerializeField] private float fadeDuration = 0.5f;
    [SerializeField] private float blinkAlpha = 0.75f;
    [SerializeField] private float blinkDuration = 1f;

    private TextMeshProUGUI _textforBegin;

 

    private void Awake()
    {
        _textforBegin = GetComponent<TextMeshProUGUI>();

        Color color = _textforBegin.color;
        color.a = 0f;
        _textforBegin.color = color;
    }

    private void Start()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.AppendInterval(delay);

        sequence.Append(
            _textforBegin.DOFade(1f, fadeDuration)
                .SetEase(Ease.OutQuad)
        );

        sequence.Append(
            _textforBegin .DOFade(blinkAlpha, blinkDuration)
                .SetLoops(-1, LoopType.Yoyo)
                .SetEase(Ease.InOutSine)
        );
        
    }
}