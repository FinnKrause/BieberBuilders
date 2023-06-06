using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultDestructionLogic : MonoBehaviour
{
    // private BoxCollider2D _bc;
    void Start()
    {
        // _bc = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Floor")
        {
            Destroy(gameObject);
        }
    }

}
