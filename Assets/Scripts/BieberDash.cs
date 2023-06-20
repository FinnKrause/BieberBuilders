using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BieberDash : MonoBehaviour
{
    private UIBar _energyBar;
    private bool dashMachen;

    public float energiekostenDash;
    public float st�rkeDash;
    public float randRechts;
    void Start()
    {
        _energyBar = GameObject.Find("EnergyBar").GetComponent<UIBar>();
    }

    
    void Update()
    {
        float _movementDirectionX = Input.GetAxis("Horizontal") * st�rkeDash;
        dashMachen = Input.GetKey("space");

        if (dashMachen == true) {   //will der spieler dashen
                if (transform.position.x + _movementDirectionX > randRechts) { _movementDirectionX = randRechts - transform.position.x; }
                if (transform.position.x + _movementDirectionX < -randRechts) { _movementDirectionX = -randRechts - transform.position.x; } // nicht �ber rand
        
            transform.Translate(_movementDirectionX,0,0);
            _energyBar.subtract(energiekostenDash);
        }
    }
}
