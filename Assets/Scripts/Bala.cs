using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage;
    HealthController healthController;

    void Start()
    {
        rb.velocity = transform.right * speed;
        Destroy(gameObject, 2f);
        healthController = GetComponent<HealthController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerManager>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject, 2);
        }


    }
}