using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Minigame1BieberLogic : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float movementRangeLeft;
    public float movementRangeRight;
    public float movementSpeed;
    public float jump;
    public bool isJumping;

    private float _width;       // Bieber width
    private float _leftmost;    // most possible position in the left of the Bieber
    private UIBar _woodPlanksBar;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _width = GetComponent<SpriteRenderer>().bounds.size.x;
        _leftmost = Camera.main.ScreenToWorldPoint(Vector3.zero).x - _width / 3.0f;
        _woodPlanksBar = GameObject.Find("WoodPlanksBar").GetComponent<UIBar>();
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
            _rb.velocity = new Vector2(0, _rb.velocity.y);
        }
        
        if (Input.GetKeyDown ("space") && isJumping == false)
        {
            _rb.AddForce(new Vector2(_rb.velocity.x, jump));
        }
        if(_woodPlanksBar.getCurrentValue() == _woodPlanksBar.maxValue)
        {
            SceneManager.LoadScene(sceneName:"Level 2");
            return;
        }        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        string _tag = other.gameObject.tag;
        switch (_tag)
        {
        case "Ground":
            isJumping = false;
            break;
        case "Ast":
            _woodPlanksBar.add(1f);
            Destroy(other.gameObject);
            break;
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
