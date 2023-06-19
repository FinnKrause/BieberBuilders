using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Startscrene : MonoBehaviour
{
    private Button _startButton;
    private Button _manualButton;

    void Start()
    {
        _startButton = GameObject.Find("Start").GetComponent<Button>();
        _manualButton = GameObject.Find("ElEmanuel").GetComponent<Button>();

        _manualButton.onClick.AddListener(delegate ()
        {
            UnityEngine.Debug.Log("Manual Button pressed!");
            SceneManager.LoadScene(sceneName: "Manual");
        });

        _startButton.onClick.AddListener(() =>
        {
            UnityEngine.Debug.Log("Start Button pressed!");
            SceneManager.LoadScene(sceneName: "Level 1");
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