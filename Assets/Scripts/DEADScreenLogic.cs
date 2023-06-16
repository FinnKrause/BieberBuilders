using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class DEADScreenLogic : MonoBehaviour
{
    private Button _retryButton;
    private Button _quitButton;

    void Start()
    {
        _retryButton = GameObject.Find("RetryButton").GetComponent<Button>();
        _quitButton = GameObject.Find("QuitButton").GetComponent<Button>();

        _retryButton.onClick.AddListener(delegate ()
        {
            UnityEngine.Debug.Log("Retry Button pressed!");
            SceneManager.LoadScene(sceneName: "Main");
        });

        _quitButton.onClick.AddListener(() =>
        {
            UnityEngine.Debug.Log("Quit button pressed!");
        });
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {

    }

}