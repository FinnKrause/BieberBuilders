using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantFalling : MonoBehaviour
{
    // lässt die Prefabs mit constanter geschwindigkeit statt beschleunigend fallen

    // Problem : Masse Rigedbodys
    public float maxGeschwindigkeit;
    private float fallgeschwindigkeit;
    //private Vector2 position; //macht strudel
    void Start()
    {
        fallgeschwindigkeit=0.1f * Random.Range(1f, maxGeschwindigkeit);
    }

    
    void Update()
    {
        //transform.position = position; //macht strudel
        transform.Translate(Vector2.down * Time.deltaTime);
        //position = transform.position; //macht strudel
    }
}
