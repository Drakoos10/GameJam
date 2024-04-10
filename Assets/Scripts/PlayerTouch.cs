using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouch : MonoBehaviour
{
    PlayerManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager= GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Obstacle")
        {
            manager.Die();
            
        }
    }
}
