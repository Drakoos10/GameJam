using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoEnemigo : MonoBehaviour
{
    public float vida=50;
    public int damage; 
    public Animator animator;
    HealthController healthController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerManager>().TakeDamage(damage);
            
        }
    }
     public void TakeDamage(int damage)
    {
        vida -= damage;
        

        if (vida <= 0)
        {
            animator.SetTrigger("Muerto");
        }
    }
    public void Die(){
        Destroy(gameObject);
    }
}
