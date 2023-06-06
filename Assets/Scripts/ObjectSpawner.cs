using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    private float _move;
    private int _count = 0;
    private float _spawnY;

    public GameObject woodPrefab;
    public GameObject dynamicGameElements;
    public float spawnInterval;
    public float spawnXRange = 10;
    public float speed;


    void Start()
    {
        _spawnY = Camera.main.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y;
        spawnXRange = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x;
        StartCoroutine(SpawnObjects());
    }

    void Update()
    {

    }

    private IEnumerator SpawnObjects()
    {
        yield return new WaitForSeconds(spawnInterval);

        while (true)
        {
            float spawnX = Random.Range(-spawnXRange, spawnXRange);
            Vector2 spawnPosition = new Vector2(spawnX, _spawnY);
            Instantiate(woodPrefab, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
