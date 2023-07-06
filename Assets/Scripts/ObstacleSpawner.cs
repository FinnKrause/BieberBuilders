using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private IEnumerator SpawnObjects()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Vector2 spawnPosition = new Vector2(12.5f, -3.03f);

            Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity); //Prefab an ort, unrotiert
        }
    }
}
