using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool atacando = true;
    
    // Start is called before the first frame update
    void Start()
    {
       if(Instance!=null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        } 
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
