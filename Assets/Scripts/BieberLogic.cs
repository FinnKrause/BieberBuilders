using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BieberLogic : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _movementDirection;
    public float movementSpeed;
    private UIBar _healthBar;
    private UIBar _energyBar;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _healthBar = GameObject.Find("HealthBar").GetComponent<UIBar>();
        _energyBar = GameObject.Find("EnergyBar").GetComponent<UIBar>();
    }

    void Update()
    {
        _movementDirection = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector2(_movementDirection * movementSpeed, _rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wood")
        {
            _healthBar.subtract(2f);
            _energyBar.subtract(5f);

            Destroy(other.gameObject);
            Debug.Log("Collision with wood detected!");
        }
    }
}
