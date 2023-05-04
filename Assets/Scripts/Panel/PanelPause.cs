using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelPause : MonoBehaviour
{
    public void Continue()
    {
        UIManager.Instance.DeActivePanelPause();
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void MenuSetting()
    {
       
        UIManager.Instance.DeActivePanelPause();
        UIManager.Instance.SetActivePanelSetting();
    }
}
