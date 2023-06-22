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

    private void Start()
    {
        _energyBar = GameObject.Find("EnergyBar").GetComponent<UIBar>();
    }

    private void Update()
    {
        float movementDirectionX = Input.GetAxis("Horizontal") * dashStrength;
        performDash = Input.GetKey("space");

        if (performDash)
        {
            movementDirectionX = Mathf.Clamp(movementDirectionX, -rightBoundary - transform.position.x, rightBoundary - transform.position.x);
            transform.Translate(movementDirectionX, 0, 0);
            _energyBar.subtract(dashEnergyCost);
        }
    }
}