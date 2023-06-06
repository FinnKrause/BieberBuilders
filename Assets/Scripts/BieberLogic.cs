using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BieberLogic : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float movementSpeed;
    private UIBar _healthBar;
    private UIBar _energyBar;
    private UIBar _woodPlanksBar;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.freezeRotation = true;
        _healthBar = GameObject.Find("HealthBar").GetComponent<UIBar>();
        _energyBar = GameObject.Find("EnergyBar").GetComponent<UIBar>();
        _woodPlanksBar = GameObject.Find("WoodPlanksBar").GetComponent<UIBar>();
    }

    void Update()
    {
        float _movementDirectionX = Input.GetAxis("Horizontal");
        // float _movementDirectionY = Input.GetAxis("Vertical");
        _rb.velocity = new Vector2(_movementDirectionX * movementSpeed, _rb.velocity.y); //_movementDirectionY * movementSpeed
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Floor") return;

        switch (other.gameObject.name)
        {
            case "Wood(Clone)":
                _woodPlanksBar.add(1f); break;
            case "Leaf(Clone)":
                _energyBar.add(5f); break;
            case "bomb(Clone)":
                _healthBar.subtract(1f); break;
            default:
                break;
        }

        Destroy(other.gameObject);
        Debug.Log($"Collision with {other.gameObject.tag} detected!");
    }
}
