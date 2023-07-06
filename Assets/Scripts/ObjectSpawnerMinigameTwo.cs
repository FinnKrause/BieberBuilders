using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnerMinigameTwo : MonoBehaviour
{
    private float _spawnY;
    public int howMuchWood;
    public float initialSpawnInterval = 1f;
    public float spawnXRange = 6;
    private float spawnInterval;
    private Min2creatingDam min2CreatingDam;
    public GameObject woodPrefab; //unbedingt Prefab machen

    void Start()
    {
        _spawnY = Camera.main.ScreenToWorldPoint(new Vector3(0f, Screen.height + 20f, 0f)).y;
        spawnInterval = initialSpawnInterval;
    }

    public void spawnTheWood()
    {
        for (int i=0; i<howMuchWood; i++)
        {
            float spawnX = Random.Range(-spawnXRange, spawnXRange);
            Vector2 spawnPosition = new Vector2(spawnX, _spawnY);

            Instantiate(woodPrefab, spawnPosition, Quaternion.identity); 
        }
    }
}