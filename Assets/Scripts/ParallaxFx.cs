using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxFx : MonoBehaviour
{
    public Camera cam;
    public Transform subject;

    Vector2 startPosition;

    float startZ;

    Vector2 travel =>(Vector2)cam.transform.position-startPosition;

    float distanceFromSubject => transform.position.z -subject.position.z;


    Vector2 parallaxFactor;

    public void Start()
    {
        startPosition = transform.position;
        startZ = transform.position.z;
    }

    public void Update()
    {
        transform.position = startPosition+ travel;
    }

}
