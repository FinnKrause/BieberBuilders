using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    private float _spawnY;

    public GameObject[] Prefabs;
    public float initialSpawnInterval = 1f;
    public float spawnXRange = 6;
    public float bombFrequency;
    public float leafFrequency;
    public float woodFrequency;
    private float spawnInterval;

    private Dictionary<GameObject, float> spawnWeights = new Dictionary<GameObject, float>();

    public GameObject bombPrefab;
    public GameObject leafPrefab;
    public GameObject woodPrefab;

    void Start()
    {
        _spawnY = Camera.main.ScreenToWorldPoint(new Vector3(0f, Screen.height + 20f, 0f)).y;
        spawnInterval = initialSpawnInterval;
        AdjustRelativeFrequencies(); //method sets weights
        StartCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            float spawnX = Random.Range(-spawnXRange, spawnXRange);
            Vector2 spawnPosition = new Vector2(spawnX, _spawnY);

            GameObject selectedPrefab = SelectObject();
            Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
        }
    }

    private GameObject SelectObject()
    {
        float totalWeight = 0f;
        foreach (var pair in spawnWeights)
        {
            totalWeight += pair.Value;
        }

        float randomValue = Random.Range(0f, totalWeight);
        float cumulativeWeight = 0f;

        foreach (var pair in spawnWeights)
        {
            cumulativeWeight += pair.Value;
            if (randomValue <= cumulativeWeight)
            {
                return pair.Key;
            }
        }

        return Prefabs[0]; //default prefab
    }
        private void AdjustRelativeFrequencies()
    {
        AdjustRelativeFrequency(bombPrefab, bombFrequency);
        AdjustRelativeFrequency(leafPrefab, leafFrequency);
        AdjustRelativeFrequency(woodPrefab, woodFrequency);
    }
    public void AdjustRelativeFrequency(GameObject prefab, float weight)
    {
        if (spawnWeights.ContainsKey(prefab))
        {
            spawnWeights[prefab] = weight;
        }
        else
        {
            spawnWeights.Add(prefab, weight);
        }
    }
}
