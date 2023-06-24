using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{ 
    private float spawnY;

    public GameObject prefab;
    public float initialSpawnInterval = 1f;
    public float spawnXRange = 6f;
    public float spawnInterval;

    public int nextItem;
    public int numberOfItems;

    private Dictionary<int, ItemEffect> itemEffects;

    void Start()
    {
        spawnY = Camera.main.ScreenToWorldPoint(new Vector3(0f, Screen.height + 20f, 0f)).y;
        spawnInterval = initialSpawnInterval;

        // Initialize item effects
        itemEffects = new Dictionary<int, ItemEffect>();
        itemEffects.Add(0, new DoubleSpeedEffect());
        itemEffects.Add(1, new HealEffect());
        // Add more items and their respective effects as needed

        SetNextItemAuto();
        StartCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            float spawnX = Random.Range(-spawnXRange, spawnXRange);
            Vector2 spawnPosition = new Vector2(spawnX, spawnY);

            Instantiate(prefab, spawnPosition, Quaternion.identity);
            ApplyItemEffect(nextItem, GetComponent<BieberLogic>());
            SetNextItemAuto();
        }
    }

    private void SetNextItemAuto()
    {
        nextItem = Random.Range(0, numberOfItems);
        ApplyItemEffect(nextItem, GetComponent<BieberLogic>());
    }

    private void ApplyItemEffect(int itemNumber, BieberLogic bieber)
    {
        if (itemEffects.ContainsKey(itemNumber))
        {
            ItemEffect itemEffect = itemEffects[itemNumber];
            itemEffect.ApplyEffect(bieber);
            Debug.Log("Applying item effect: " + itemEffect.EffectName);
        }
        else
        {
            Debug.LogWarning("No item effect defined for item number: " + itemNumber);
        }
    }
}

/*every item effect is represented by the ItemEffect class that has a property for the effect name
add methods for every new effect*/