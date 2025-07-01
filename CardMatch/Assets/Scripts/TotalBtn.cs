using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TotalBtn : MonoBehaviour
{
    [SerializeField]
    GameObject LvPopup;

    public void OnClickPlayBtn()
    {
        LvPopup.SetActive(true);
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
