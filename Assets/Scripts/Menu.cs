using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void ChuyenMain()
    {
        SceneManager.LoadScene("Main");
    }
    
    public void ChuyenCredit()
    {
        SceneManager.LoadScene("Credit");
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}