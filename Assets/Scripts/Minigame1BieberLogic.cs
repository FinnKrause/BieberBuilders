using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Minigame1BieberLogic : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float movementRangeLeft;
    public float movementRangeRight;
    public float movementSpeed;
    public float jump;
    public bool isJumping;

    private bool _collision;    // state of collistion the Bieber and Obstacle
    private float _width;       // Bieber width
    private float _leftmost;    // most possible position in the left of the Bieber

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _collision = false;
        _width = GetComponent<SpriteRenderer>().bounds.size.x;
        _leftmost = Camera.main.ScreenToWorldPoint(Vector3.zero).x - _width / 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= _leftmost)
        {   // the Bieber is completely out of view, destroy it
            Destroy(gameObject);
            // change the scene to Death
            SceneManager.LoadScene(sceneName: "Death");
            return;
        }
        float _movementDirectionX = Input.GetAxis("Horizontal");
        if (_collision == true)
        {
            _rb.velocity = new Vector2(-2, _rb.velocity.y);            
        }
        else if (_movementDirectionX == 0 && transform.position.x > movementRangeLeft)
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
            _rb.velocity = new Vector2(0, _rb.velocity.y);
        }
        
        if (Input.GetKeyDown ("space") && isJumping == false)
        {
            _rb.AddForce(new Vector2(_rb.velocity.x, jump));
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
        else if (other.gameObject.CompareTag("obstacle(Clone)"))
        {   // the Bieber collided with the Obstacle
            _collision = true;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }

}
