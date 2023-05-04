using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance { get => _instance; }
    
    [SerializeField] protected GameObject panelLevelUp;
    [SerializeField] protected GameObject pannelGameOvel;
    [SerializeField] protected GameObject pannelSetting;
    public GameObject panelPause;
    [SerializeField] protected Text level;
    [SerializeField] protected Text countEnemy;
    protected void Awake()
    {
        UIManager._instance = this;
    }

    public void SetActivePanelLevelUp(bool enabled)
    {
        
        if (enabled)
        {
            MusicManager.Instance.SetMusic(true);
            GameController.Instance.PauseGame();
        }
        else
        {
            MusicManager.Instance.SetMusic(false);
            GameController.Instance.ContinueGame();
        }
        panelLevelUp.SetActive(enabled);
    }

    public void SetActivePanelPause()
    {
        GameController.Instance.PauseGame();
        panelPause.SetActive(true);
    }

    public void DeActivePanelPause()
    {
        GameController.Instance.ContinueGame();
        panelPause.SetActive(false);
    } 
    public void SetActivePanelGameOver()
    {
        MusicManager.Instance.OnPlayMusic(MusicType.GameOver);
        GameController.Instance.PauseGame();
        pannelGameOvel.SetActive(true);
    }

    public void DeActivePanelGameOver()
    {
        GameController.Instance.ResetScene();
        pannelGameOvel.SetActive(false);
        SceneManager.LoadScene("Menu");
    }
    
    public void SetActivePanelSetting()
    {
        GameController.Instance.PauseGame();
        pannelSetting.SetActive(true);
    }

    public void DeActivePanelSetting()
    {
        pannelSetting.SetActive(false);
    }

    public void SetLevel(int lv)
    {
        level.text = "LV: " + lv.ToString();
    }
    
    public void SetEnemy(int enemy)
    {
        countEnemy.text = enemy.ToString();
    }
}
