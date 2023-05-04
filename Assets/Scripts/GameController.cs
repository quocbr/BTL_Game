using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


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

    public int countEnemyKill = 0;
    public int Level = 1;

    protected void Awake()
    {
        GameController._instance = this;
    }

    protected void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (UIManager.Instance.panelPause.activeSelf == false)
            {
                UIManager.Instance.SetActivePanelPause();
            }
            else
            {
                UIManager.Instance.DeActivePanelPause();
            }
        }
    }

    public void AddKillEnemy(int count = 1)
    {
        countEnemyKill += count;
        SoundManager.Instance.OnPlaySound(SoundType.ghostdead);
        UIManager.Instance.SetEnemy(countEnemyKill);
    }

    public void AddLevel(int count = 1)
    {
        Level += count;
        SoundManager.Instance.OnPlaySound(SoundType.levelup);
        UIManager.Instance.SetLevel(Level);
        if (Level % 5 == 0)
        {
            if (SpawnPoints.Instance.spawnerRate > 0.5f)
            {
                SpawnPoints.Instance.spawnerRate -= 0.3f;
            }
            
        }
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

    public void ResetScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        Time.timeScale = 1f;
    }
}