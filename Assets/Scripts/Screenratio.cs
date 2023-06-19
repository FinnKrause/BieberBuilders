using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screneratio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int targetHeight = Screen.width * 9/16;
        Screen.SetResolution(Screen.width, targetHeight, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
