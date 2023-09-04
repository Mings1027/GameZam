using System;
using ManagerControl;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float _curHealth;
    [SerializeField] private Image healthImage;
    public float decreaseSpeed;
    public float decreaseAmount;
    [SerializeField] private float maxHealth;

    private void Start()
    {
        decreaseAmount = 0.5f;
        _curHealth = maxHealth;
        healthImage.fillAmount = _curHealth / maxHealth;
        InvokeRepeating(nameof(DecreaseHealth), 0, decreaseSpeed);
    }

    public void OnDisable()
    {
        CancelInvoke();
        _curHealth += 1000;
    }

    private void DecreaseHealth()
    {
        _curHealth -= decreaseAmount;
        healthImage.fillAmount = _curHealth / maxHealth;
        if (_curHealth <= 0)
        {
            GameManager.Instance.GameOver();
        }
    }

    public void ObstacleDecreaseHealth(int amount)
    {
        _curHealth -= amount;
        healthImage.fillAmount = _curHealth / maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Food"))
        {
            if (_curHealth < 100)
            {
                SoundManager.Instance.PlaySound(SoundManager.GetClam);
                _curHealth += other.GetComponent<Food>().increaseHealthAmount;
                if (_curHealth > 100) _curHealth = maxHealth;
            }

            other.gameObject.SetActive(false);
        }
        else if (other.CompareTag("KillerWhale") || other.CompareTag("Monkfish"))
        {
            ObstacleDecreaseHealth(30);
        }
    }
}