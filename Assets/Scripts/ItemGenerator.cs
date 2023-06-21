using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{   //basiert auf Object spawner, eigenes Script um Items unabhängiger steuern zu können und überschneidungen zu vermeiden
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

            setNextItemAuto();
            Instantiate(prefab, spawnPosition, Quaternion.identity); //Prefab an ort, unrotiert
        }
    }

    private void setNextItemAuto()
    {
        nextItem = Random.Range(0, wievieleItems);
    }
}

    //Weiterer Plan für die Items ist, dass sie in ihrer Startmethode die nächste Zahl bekommen ud speichern
    //Der Itemeffeckt soll von der Zahl abhängen