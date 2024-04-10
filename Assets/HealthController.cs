using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    private int maxHealth = 100;
    private int currentHealth;
    public HealthBar healthBar;
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private int damageAmount;

    private void Start()
    {
        healthBar = GetComponent<HealthBar>();  
    }
    private void Awake()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            TakeDamage(damageAmount);
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth= Mathf.Clamp(currentHealth,0, maxHealth);
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
           playerManager.Die();
        }
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        healthBar.SetHealth(currentHealth);

    }

}
