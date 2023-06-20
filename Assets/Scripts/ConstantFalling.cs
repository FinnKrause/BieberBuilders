using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantFalling : MonoBehaviour
{
    // l�sst die Prefabs mit constanter geschwindigkeit statt beschleunigend fallen

    // Problem : Masse Rigedbodys
    public float fallSpeed;
    //private Vector2 position; //macht strudel
    void Start()
    {
        fallSpeed = Random.Range(1f, fallSpeed);
    }

    
    void Update()
    {
        //transform.position = position; //macht strudel
        transform.Translate(Vector2.down * Time.deltaTime * fallSpeed);//Feature: Unequal speed leads to collisions
        //position = transform.position; //macht strudel
    }
}
