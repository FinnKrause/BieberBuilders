using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame1BieberLogic : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float movementRangeLeft;
    public float movementRangeRight;
    public float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        // _rb.velocity=new Vector2(1,0);
    }

    // Update is called once per frame
    void Update()
    {
         float _movementDirectionX = Input.GetAxis("Horizontal");

        if (_movementDirectionX == 0 && transform.position.x > movementRangeLeft)
        {
            _rb.velocity = new Vector2(-2, _rb.velocity.y);
        }
        else if (transform.position.x < movementRangeRight && transform.position.x > movementRangeLeft)
        {
            _rb.velocity = new Vector2(_movementDirectionX * movementSpeed, _rb.velocity.y);
        }
        else if (transform.position.x >= movementRangeRight && _movementDirectionX < 0)
        {
            _rb.velocity = new Vector2(_movementDirectionX * movementSpeed, _rb.velocity.y);
        }
        else if (transform.position.x <= movementRangeLeft && _movementDirectionX > 0)
        {
            _rb.velocity = new Vector2(_movementDirectionX * movementSpeed, _rb.velocity.y);
        }
        else
        {
            _rb.velocity = new Vector2(0, 0);
        }
    }
}
