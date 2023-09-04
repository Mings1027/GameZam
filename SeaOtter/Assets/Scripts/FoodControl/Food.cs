using System;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class Food : MonoBehaviour
{
    private Tween _moveTween;
    private SpriteRenderer _spriteRenderer;
    public float increaseHealthAmount;

    [SerializeField] private Sprite[] sprite;
    [SerializeField] private float foodMoveSpeed;
    [SerializeField] private Ease movingEase;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        var ranIndex = Random.Range(0, sprite.Length);
        _spriteRenderer.sprite = sprite[ranIndex];
        _moveTween = transform.DOMoveY(transform.position.y - 3, foodMoveSpeed).SetLoops(-1, LoopType.Yoyo)
            .SetEase(movingEase);
    }

    private void OnDisable()
    {
        _moveTween.Kill();
    }
}