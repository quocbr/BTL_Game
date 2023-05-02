using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance { get => _instance; }
    
    [SerializeField] protected GameObject panelLevelUp;
    [SerializeField] protected Animator animator;
    [SerializeField] protected Text level;
    protected void Awake()
    {
        UIManager._instance = this;
    }

    public void SetActivePanelLevelUp(bool enabled)
    {
        
        if (enabled)
        {
            Time.timeScale = 0f; // Tạm dừng trò chơi
            animator.enabled = true;
        }
        else
        {
            Time.timeScale = 1f; // Tiếp tục trò chơi
            animator.enabled = false;
        }
        panelLevelUp.SetActive(enabled);
    }

    public void SetLevel(int lv)
    {
        level.text = "LV: " + lv.ToString();
    }
}
