using System;
using System.Collections;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    private float _spawnY;

    public GameObject[] Prefabs;
    public float spawnInterval;
    public float spawnXRange = 10;

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
            float spawnX = UnityEngine.Random.Range(-spawnXRange, spawnXRange);
            Vector2 spawnPosition = new Vector2(spawnX, _spawnY);
            Instantiate(Prefabs[UnityEngine.Random.Range(0, Prefabs.Length)], spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
