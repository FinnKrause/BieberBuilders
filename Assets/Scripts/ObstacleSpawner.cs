using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float InitialSpawnInterval = 1f;

    private float _spawnInterval;
    private float _spawnX;
    private float _obshei;
    private float _scrhei;

    // Start is called before the first frame update
    void Start()
    {
        _spawnInterval = InitialSpawnInterval;
        _spawnX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width + 10f, 0f, 0f)).x;
        _scrhei = Camera.main.ScreenToWorldPoint(new Vector3(Screen.height, 0f, 0f)).y;
        _obshei = obstaclePrefab.GetComponent<SpriteRenderer>().bounds.size.y;
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
            yield return new WaitForSeconds(_spawnInterval);
            // get initial start position
            Vector2 spawnPosition = new Vector2(_spawnX, 0f);

            // get obstacle or enemy

             // clone the obstacle
            GameObject created = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
 
            // change obstacle geometry by random
            created.transform.localScale = new Vector3(1.5f, Random.Range(1.5f, 3f), 1f);
            created.transform.position = new Vector2(_spawnX, (_scrhei - _obshei) / 2.0f);
        }
    }
}
