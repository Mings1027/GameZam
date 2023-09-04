using DG.Tweening;
using UnityEngine;

public class NotifyObstacle : MonoBehaviour
{
    private Tween scaleTween;
    [SerializeField] private float scaleSpeed;

    private void OnEnable()
    {
        var localScale = transform.localScale;
        localScale.y = 1;
        transform.localScale = localScale;
        scaleTween = transform.DOScaleY(0, scaleSpeed);
    }

    private void OnDisable()
    {
        scaleTween.Kill();
    }
}