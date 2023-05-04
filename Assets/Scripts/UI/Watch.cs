using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Watch : MonoBehaviour
{
    private static Watch _instance;

    public static Watch Instance
    {
        get => _instance;
    }
    public Text stopwatchText;
    private float elapsedTime;

    protected void Awake()
    {
        Watch._instance = this;
    }
    
    private void Start()
    {
        stopwatchText.text = "00:00";
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);
        stopwatchText.text = timerString;
    }
}
