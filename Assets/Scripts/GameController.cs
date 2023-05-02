using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController _instance;
    public static GameController Instance { get => _instance; }
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

    public void AddKillEnemy(int count = 1)
    {
        countEnemyKill += count;
    }
    
    public void AddLevel(int count = 1)
    {
        Level += count;
        UIManager.Instance.SetLevel(Level);
    }
    
}
