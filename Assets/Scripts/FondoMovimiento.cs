using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoMovimiento : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Vector2 velocidadMovimiento;

    private Vector2 offset;
    private Material material;
    private Rigidbody2D playerRb;


    private void Awake()
    {
        material =GetComponent<SpriteRenderer>().material;
        playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();  
    }
    private void Update()
    {
        offset= (playerRb.velocity.x/10)* velocidadMovimiento*Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
