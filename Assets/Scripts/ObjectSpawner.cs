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

    private float zahl;
    private int obi = 1;
    private float bombe = 1;
    private float blatt = 1;
    private float holz = 1;
    public float mehrBombe;
    public float mehrBlatt;
    public float mehrHolz;

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
            GameObject rbdObj = Prefabs[Objectwaehler()];
            Instantiate(rbdObj, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private int Objectwaehler(){
        zahl = UnityEngine.Random.Range(0,bombe+blatt+holz);
        if(zahl<=bombe){
            obi = 0;
            blatt = blatt*mehrBlatt;
            holz = holz*mehrHolz;
            bombe = 1;
            return obi;
        }else if(zahl<=bombe+blatt){
            obi = 1;
            bombe = bombe*mehrBombe;
            holz = holz*mehrHolz;
            blatt = 1;
            return obi;
        }else if(zahl<=bombe+blatt+holz){
            obi = 2;
            bombe = bombe*mehrBombe;
            blatt = blatt*mehrBlatt;
            holz = 1;
            return obi;
    }
return 1;

}
}
