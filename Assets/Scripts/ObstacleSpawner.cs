using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    //private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObjects());
    //    _rb = GetComponent<Rigidbody2D>();
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
            //_rb.velocity = new Vector2(-2, _rb.velocity.y);
        }
    }
}
