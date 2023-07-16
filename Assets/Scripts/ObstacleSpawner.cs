using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject ast1Prefab;
    public GameObject ast2Prefab;
    public GameObject ast3Prefab;
    public GameObject ast4Prefab;
    public GameObject ast5Prefab;
    public float InitialSpawnInterval = 1f;

    private float _spawnInterval;
    private float _spawnX;
    private float _scrhei;

    // Start is called before the first frame update
    void Start()
    {
        _spawnInterval = InitialSpawnInterval;
        _spawnX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width + 10f, 0f, 0f)).x;
        _scrhei = Camera.main.ScreenToWorldPoint(new Vector3(Screen.height, 0f, 0f)).y;
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

            // get obstacle or wood
            GameObject _object = SelectObject();

             // clone the obstacle
            GameObject created = Instantiate(_object, spawnPosition, Quaternion.identity);
 
            // change obstacle geometry by random
 
            // change cloned object's position
            float _height = created.GetComponent<SpriteRenderer>().bounds.size.y;
            created.transform.position = new Vector2(_spawnX, (_scrhei - _height) / 2.0f);

            if (_object == obstaclePrefab)
                created.transform.localScale = new Vector3(1.5f, Random.Range(1.5f, 3f), 1f);
        }
    }

    private GameObject SelectObject()
    {
        int number = Random.Range(0, 12);
        switch (number)
        {
        case 0: return ast1Prefab;
        case 1: return ast2Prefab;
        case 2: return ast3Prefab;
        case 3: return ast4Prefab;
        case 4: return ast5Prefab;
        }
        return obstaclePrefab;
    }

}
