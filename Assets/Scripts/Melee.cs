using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    [SerializeField] private Transform controlGolpe;
    [SerializeField] private float radioGolpe;
    [SerializeField] private float damageGolpe;
    [SerializeField] private float tiempoEntreAtaque;
    [SerializeField] private float tiempoSigAtaque;

    private Animator anim;
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !anim.GetBool("Salto"))
        {
            GameManager.Instance.atacando = true;
            anim.SetTrigger("Attack");
            tiempoSigAtaque = tiempoEntreAtaque;
        }
        if (tiempoSigAtaque > 0)
        {
            tiempoSigAtaque -= Time.deltaTime;
        }
    }
    public void Atacar()
    {
        try
        {
            Collider2D enemigo = Physics2D.OverlapCircle(controlGolpe.position, radioGolpe);

            if (enemigo.CompareTag("Enemigo"))
            {
                enemigo.transform.GetComponent<Enemigo>().getDamage(damageGolpe);
            }
        }
        catch
        {

        }

    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controlGolpe.position, radioGolpe);
    }
}

