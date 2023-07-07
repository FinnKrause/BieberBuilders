using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Min2collector : MonoBehaviour
{
    public int howMuchToGet;
    private int woodCollected;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (woodCollected >= howMuchToGet) {
            Debug.Log("win");
            SceneManager.LoadScene(sceneName: "Level 2");
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Floor") return;

        switch (other.gameObject.name)
        {
            case "Wood(Clone)":
                woodCollected++;
                break;
            default:
                break;
        }

        Destroy(other.gameObject);
    }
}
