using DG.Tweening;
using UnityEngine;

public class backgroundAnimation : MonoBehaviour
{
    [SerializeField] private Transform background1;
    [SerializeField] private Transform background2;

    [SerializeField] private float moveDistance = 20f; 
    [SerializeField] private float duration = 2f;      

    private void Start()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(background1.DOMoveY(background1.position.y - moveDistance, duration).SetEase(Ease.Linear));
        sequence.Join(background2.DOMoveY(background2.position.y - moveDistance, duration).SetEase(Ease.Linear));

        sequence.OnStepComplete(() =>
        {
            if (background1.position.y <= -moveDistance)
                background1.position += Vector3.up * moveDistance * 2;

            if (background2.position.y <= -moveDistance)
                background2.position += Vector3.up * moveDistance * 2;
        });

        sequence.SetLoops(-1, LoopType.Restart);
    }
}