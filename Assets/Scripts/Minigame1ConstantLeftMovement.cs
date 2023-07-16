using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame1ConstantLeftMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private float _leftmost;
    private float _width;
    void Start()
    {
        // get GameObject's width
        _width = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;

        // left most position to be used to destroy the GameObject
        // is Screen(0, 0) - width 
        _leftmost = Camera.main.ScreenToWorldPoint(Vector3.zero).x - _width;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= _leftmost)
        {   // the GameObject is completely out of view, destroy it
            Destroy(gameObject);
        }
        else
        {   // move to the left
            transform.Translate(Vector2.left * Time.deltaTime * 2f);
        }    
    }
}
