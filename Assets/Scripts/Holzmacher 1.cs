using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Holzmacher1 : MonoBehaviour
{
    public GameObject objectPrefab;  // The prefab of the object to create
    public int numberOfObjects = 10; // Number of objects to create
    public float spawnRadius = 5f;   // Radius within which objects will be spawned

    private void Start()
    {
        // Create objects
        for (int i = 0; i < numberOfObjects; i++)
        {
            // Generate random position within spawn radius
            Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;

            // Create the object
            GameObject newObj = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
            
        }
    }
}

