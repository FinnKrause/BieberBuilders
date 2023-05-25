using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterfall : MonoBehaviour
{
    public GameObject SquareContainer;      //
    public GameObject objectPrefab;         // Das Prefab des fallenden Objekts
    public float spawnInterval = 1f;        // Zeitintervall für das Erzeugen der Objekte
    public float objectSpeed = 3f;          // Geschwindigkeit, mit der das Objekt nach unten fällt
    public float deleteYPosition = -10f;    // Y-Position, bei der das Objekt gelöscht wird

    private float spawnTimer = 0f;          // Timer für das Erzeugen der Objekte

    private void Start() {
       SquareContainer=GameObject.Find("SquareContainer");
       if (SquareContainer is null) {
        // Console.WriteLie("Object could not be found!");
       }
    }

    private void Update()
    {

        // Timer aktualisieren
        spawnTimer += Time.deltaTime;

        // Objekte erzeugen, wenn das Zeitintervall abgelaufen ist
        if (spawnTimer >= spawnInterval)
        {
            SpawnObject();
            spawnTimer = 0f;
        }
        FixedUpdate();
    }

    private void SpawnObject()
    {
        // Zufällige X-Position innerhalb des sichtbaren Bereichs
        float randomX = Random.Range(Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x,
                                      Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x);

        // Objekt erstellen
        GameObject newObj = Instantiate(objectPrefab, new Vector3(randomX, transform.position.y, 0), Quaternion.identity);

        // Rigidbody-Komponente abrufen und die Geschwindigkeit setzen
        Rigidbody2D rb = newObj.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * objectSpeed;
    }

    private void FixedUpdate()
    {
        // Überprüfen, ob Objekte die Löschposition erreicht haben
        foreach (GameObject child in SquareContainer.GetChild()){
            if(!child.GetComponent<Renderer>().isVisible){
                Destroy(child.gameObject);

            }
            

        // foreach (Transform child in transform)
        // {
        //     if (child.position.y <= deleteYPosition)
        //     {
                
        //     }
     }
    }
}
