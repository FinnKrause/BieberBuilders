using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BieberLogic : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float movementSpeedAmplifier;
    public float movementRangeLeft;
    public float movementRangeRight;
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

        //movement Speed in Abhängigkeit von der Energy
        float movementSpeed = _energyBar.getCurrentValue() / 5 * movementSpeedAmplifier;

        UnityEngine.Debug.Log(transform.position.x);//Screen 909
        if (transform.position.x < movementRangeRight && transform.position.x > -movementRangeLeft)
        {
            _rb.velocity = new Vector2(_movementDirectionX * movementSpeed, _rb.velocity.y);
        }
        else if (transform.position.x >= movementRangeRight && _movementDirectionX < 0)
        {
            _rb.velocity = new Vector2(_movementDirectionX * movementSpeed, _rb.velocity.y);
        }
        else if (transform.position.x <= -movementRangeLeft && _movementDirectionX > 0)
        {
            _rb.velocity = new Vector2(_movementDirectionX * movementSpeed, _rb.velocity.y);
        }
        else
        {
            _rb.velocity = new Vector2(0, 0);
        }
        // if(_healthBar.getCurrentValue() == 0) {
        //     SceneManager.LoadScene(sceneName:"Put the name of the scene here");
        // }

    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Floor") return;

        switch (other.gameObject.name)
        {
            case "Wood(Clone)":
                _woodPlanksBar.add(1f); break;
            case "Leaf(Clone)":
                _energyBar.add(20f); break;
            case "bomb(Clone)":
                _healthBar.subtract(1f); break;
            default:
                break;
        }

        Destroy(other.gameObject);
        Debug.Log($"Collision with {other.gameObject.tag} detected!");
    }
}
