using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController _instance;

    public static GameController Instance
    {
        get => _instance;
    }

    [SerializeField] protected Camera mainCamera;

    public Camera MainCamera
    {
        get => mainCamera;
    }

    [SerializeField] protected int countEnemyKill = 0;
    public int Level = 1;

    protected void Awake()
    {
        GameController._instance = this;
    }

    protected void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            UIManager.Instance.SetActivePanelPause();
        }
    }

    public void AddKillEnemy(int count = 1)
    {
        countEnemyKill += count;
        UIManager.Instance.SetEnemy(countEnemyKill);
    }

    public void AddLevel(int count = 1)
    {
        Level += count;
        UIManager.Instance.SetLevel(Level);
    }

    public void PauseGame()
    {
        Cursor.visible = true;
        Time.timeScale = 0f;
    }

    public void ContinueGame()
    {
        Cursor.visible = false;
        Time.timeScale = 1f;
    }
}