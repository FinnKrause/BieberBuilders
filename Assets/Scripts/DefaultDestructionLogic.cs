using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultDestructionLogic : MonoBehaviour
{
    void Start()
    {
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Floor")
        {
            Destroy(gameObject);
        }
    }

}
