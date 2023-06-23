using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{   //basiert auf Object spawner, eigenes Script um Items unabh�ngiger steuern zu k�nnen und �berschneidungen zu vermeiden
    private float _spawnY;

    public GameObject prefab;
    public float initialSpawnInterval = 1f;
    public float spawnXRange = 6;
    public float spawnInterval;

    public int nextItem;
    public int wievieleItems;

    void Start()
    {
        _spawnY = Camera.main.ScreenToWorldPoint(new Vector3(0f, Screen.height + 20f, 0f)).y;
        spawnInterval = initialSpawnInterval;
        StartCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            float spawnX = Random.Range(-spawnXRange, spawnXRange);
            Vector2 spawnPosition = new Vector2(spawnX, _spawnY);

            Instantiate(prefab, spawnPosition, Quaternion.identity); //Prefab an ort, unrotiert
        }
    }

    public int gibNextItemAuto()
    {
        nextItem = Random.Range(0, wievieleItems);
        return nextItem;
    }
}

    //Weiterer Plan f�r die Items ist, dass sie in ihrer Startmethode die n�chste Zahl bekommen ud speichern
    //Der Itemeffeckt soll von der Zahl abh�ngen