using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
     [Header("Salud")]
    public float salud;

    [Header("Disparo")]
    public Transform arma;
    public Transform firePoint;
    public GameObject bala;
    public float RangoPLayer = 8;

    private GameObject target;

    [SerializeField] private float tiempoDisparo;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        try{
            float distancia = Vector2.Distance(transform.position, target.transform.position);

            if (distancia < RangoPLayer)
            {
                Vector3 rotacion = target.transform.position - arma.transform.position;
                float rotZ = Mathf.Atan2(rotacion.y, rotacion.x) * Mathf.Rad2Deg;

                arma.transform.rotation = Quaternion.Euler(0, 0, rotZ);

                tiempoDisparo += Time.deltaTime;

                if (tiempoDisparo > 2)
                {
                    tiempoDisparo = 0;
                    Disparar();
                }
            }
        }catch{

        }
         
    }
   private void Disparar()
    {
        Instantiate(bala, firePoint.position, firePoint.rotation);
    }
    public void getDamage(float dmg)
    {
        salud -= dmg;
        

        if (salud <= 0)
        {
            
        Destroy(gameObject);

        }
    }
}
