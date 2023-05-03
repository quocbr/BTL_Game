using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance { get => _instance; }
    
    [SerializeField] protected GameObject panelLevelUp;
    [SerializeField] protected GameObject panelPause;
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
            GameController.Instance.PauseGame();
        }
        else
        {
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

    public void SetLevel(int lv)
    {
        level.text = "LV: " + lv.ToString();
    }
    
    public void SetEnemy(int enemy)
    {
        countEnemy.text = enemy.ToString();
    }
}
