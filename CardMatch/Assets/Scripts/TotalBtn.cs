using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TotalBtn : MonoBehaviour
{
    public void OpenScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OpenLevel()
    {
        SceneManager.LoadScene("Yechan");
    } 

    public void OnQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}
