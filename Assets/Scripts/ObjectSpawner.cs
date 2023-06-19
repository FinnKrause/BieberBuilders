using System.Collections.Generic;
using System;
using System.Collections;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    private float _spawnY;

    public GameObject[] Prefabs;
    public float spawnInterval;
    public float spawnXRange = 6;

    void Start()
    {
        _spawnY = Camera.main.ScreenToWorldPoint(new Vector3(0f, Screen.height+20, 0f)).y;
        //spawnXRange = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x;
        StartCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects()
    {
        yield return new WaitForSeconds(spawnInterval);

        while (true)
        {
            float spawnX = UnityEngine.Random.Range(-spawnXRange, spawnXRange);
            Vector2 spawnPosition = new Vector2(spawnX, _spawnY);
            GameObject rbdObj = Prefabs[UnityEngine.Random.Range(0, Prefabs.Length)];
            Instantiate(rbdObj, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
