using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    Vector2 startPos;
    SpriteRenderer spriteRenderer;
    Rigidbody2D playerRb;
    public Animator anim;
    private int healthAmount = 20; // Define la cantidad de salud que el jugador obtendrá al recoger un objeto de salud

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerRb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        startPos = transform.position;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        anim.SetTrigger("Hurt");
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {

            anim.SetBool("Dead",true);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Health"))
        {
            Heal(healthAmount);
        }
    }

    private void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBar.SetHealth(currentHealth);
    }

    public void Die()
    {
        anim.SetBool("Dead", false);
        StartCoroutine(Respawn(0.5f));
    }

    IEnumerator Respawn(float duration)
    {
        playerRb.simulated = false;
        playerRb.velocity = Vector2.zero;
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(duration);
        transform.position = startPos;
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
        spriteRenderer.enabled = true;
        playerRb.simulated = true;
        
    }
}
