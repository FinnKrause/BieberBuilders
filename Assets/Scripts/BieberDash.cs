using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BieberDash : MonoBehaviour
{
    private UIBar _energyBar;
    private bool performDash;

    public float dashEnergyCost;
    public float dashStrength;
    public float rightBoundary;

    public int extraDashes; //gained through items? 

    public float cooldownDuration = 2f; // Time between Dashes
    private float cooldownTimer = 0f;  // Timer füor Dashes


    private void Start()
    {
        _energyBar = GameObject.Find("EnergyBar").GetComponent<UIBar>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        float movementDirectionX = Input.GetAxis("Horizontal") * dashStrength;
        performDash = Input.GetKey("space");

        if (performDash)
        {
            dash(movementDirectionX);
        }
    }

    private void dash(float movementDirectionX) {
        if (extraDashes > 0)
        {
            movementDirectionX = Mathf.Clamp(movementDirectionX, -rightBoundary - transform.position.x, rightBoundary - transform.position.x);
            transform.Translate(movementDirectionX, 0, 0);
            extraDashes --;
        }else if(cooldownTimer >= cooldownDuration) 
        {
            movementDirectionX = Mathf.Clamp(movementDirectionX, -rightBoundary - transform.position.x, rightBoundary - transform.position.x);
            transform.Translate(movementDirectionX, 0, 0);
            _energyBar.subtract(dashEnergyCost);
            cooldownTimer = 0f;
        }
        
    }
}