using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    private GameObject player;
    public Transform destination;
    public SpriteRenderer portal;
    private Animator animPlayer;
    public Rigidbody2D playerRb;
    public Animator anim;
    int cont = 0;



    public float RangoPLayer = 4;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animPlayer = player.GetComponent<Animator>();
        
        playerRb = player.GetComponent<Rigidbody2D>();
        
    }

    void Update(){
        float distancia = Vector2.Distance(transform.position, player.transform.position);


        if (distancia < RangoPLayer) {
            gameObject.GetComponent<SpriteRenderer>().enabled=true;
            animacion();

            

        }
        else if(distancia > RangoPLayer){
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            anim.SetBool("Open", false);
        }
        
    }
    public void animacion()
    {
        
        if (cont > 42)
        {
            anim.SetBool("Open", true);
            cont = 1;
        }
        else
        {
            anim.SetBool("Open", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Vector2.Distance(player.transform.position, transform.position) > 0.3f)
            {
                //player.transform.position = destination.transform.position;
                StartCoroutine(PortalIn());
            }
            
        }
        
    }

    IEnumerator PortalIn()
    {
        playerRb.simulated = false;
        animPlayer.Play("Portal In");
        StartCoroutine(MoveInPortal());
        yield return new WaitForSeconds(0.5f);
        player.transform.position = destination.position;
        playerRb.velocity = Vector2.zero;
        yield return new WaitForSeconds(0.5f);
        animPlayer.Play("Portal Out");
        playerRb.simulated = true;


    }

    IEnumerator MoveInPortal()
    {
        float timer = 0;
        while (timer<0.5f)
        {
            player.transform.position=Vector2.MoveTowards(player.transform.position, transform.position, 3 * Time.deltaTime);
            yield return new WaitForEndOfFrame();
            timer += Time.deltaTime;

        }
    }

}
