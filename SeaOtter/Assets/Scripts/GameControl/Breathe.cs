using System;
using UnityEngine;
using UnityEngine.UI;

public class Breathe : MonoBehaviour
{
    [SerializeField] private float _curBreathe;
    [SerializeField] private Image BreatheImage;
    public float decreaseSpeed;
    public float decreaseAmount;
    [SerializeField] private float maxBreathe;

    // Start is called before the first frame update
    private void Start()
    {
        decreaseAmount = 0.5f;
        _curBreathe = maxBreathe;
        BreatheImage.fillAmount = _curBreathe / maxBreathe;
        InvokeRepeating(nameof(DecreaseBreathe), 0, decreaseSpeed);
    }

    public void OnDisable()
    {
        CancelInvoke();
        _curBreathe += 1000;
    }

    private void DecreaseBreathe()
    {
        _curBreathe -= decreaseAmount;
        BreatheImage.fillAmount = _curBreathe / maxBreathe;
        if (_curBreathe <= 0)
        {
            GameManager.Instance.GameOver();
        }
    }

    private void IncreaseBreathe()
    {
        _curBreathe += 0.4f;
        BreatheImage.fillAmount = _curBreathe / maxBreathe;
        if (_curBreathe >= 100)
        {
            _curBreathe = 100;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            //_curHealth -= other.GetComponent<Obstacle>().decreaseHealthAmount;
            _curBreathe -= 15;
            if (_curBreathe <= 0)
            {
                GameManager.Instance.GameOver();
            }

            other.gameObject.SetActive(false);
        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Breathing"))
        {
            IncreaseBreathe();
        }
    }

}