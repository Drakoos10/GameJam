using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo2 : MonoBehaviour
{
    [Header("Movimento")]
    public float velocidad;
    public Rigidbody2D rb;
    private Transform player;
    private bool mirandoDerecha = true;
    public float rango;
    public Animator animator;

    [Header("Salud")]
    public float salud;

    [Header("Ataque")]
    [SerializeField] private GameObject controlGolpe;
    [SerializeField] private float radioGolpe;
    [SerializeField] private int damageGolpe;
    [SerializeField] private float tiempoEntreAtaque;
    [SerializeField] private float tiempoSigAtaque;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
     float direccion = 0;
        float distancia = Vector2.Distance(transform.position, player.position);
        mirarjugador();
        if(mirandoDerecha){
            direccion=1;
        }else{
            direccion=-1;
        }
       if(distancia<=rango){
        if(distancia<1.5f){
            animator.SetBool("Move",false);
            rb.velocity = new Vector2(0,rb.velocity.y);
        }else{
            animator.SetBool("Move",true);
             rb.velocity = new Vector2(direccion*velocidad,rb.velocity.y);
        }
       }else{
        animator.SetBool("Move",false);
       }
        
    }

    public void mirarjugador()
    {
        if((player.position.x > transform.position.x && !mirandoDerecha) || (player.position.x < transform.position.x && mirandoDerecha))
        {
            mirandoDerecha= !mirandoDerecha;
            transform.eulerAngles =new Vector3(0,transform.eulerAngles.y + 180,0);
        }
    }
    public void Atacar()
    {
        try
        {
            Collider2D Player = Physics2D.OverlapCircle(controlGolpe.GetComponent<Transform>().position, radioGolpe);

            if (Player.CompareTag("Player"))
            {
                Player.transform.GetComponent<PlayerManager>().TakeDamage(damageGolpe);
            }
        }
        catch
        {

        }

    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controlGolpe.GetComponent<Transform>().position, radioGolpe);
    }

}
