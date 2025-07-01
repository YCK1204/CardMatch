using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIInGame : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI PlayTime;
    [SerializeField]
    GameObject PausePopup;
    [SerializeField]
    TextMeshProUGUI TextLv;

    #region Setters
    public void SetLevel(int level)
    {
        TextLv.text = "Lv." + level.ToString();
    }
    public void SetTime(float time)
    {
        PlayTime.text = Mathf.Clamp(time, 0, time).ToString("F2");
    }
    #endregion

    #region UI
    public void OnPause()
    {
        Time.timeScale = 0f;
        PausePopup.SetActive(true);
    }
    public void OffPause()
    {
        Time.timeScale = 1f;
        PausePopup.SetActive(false);
    }
    public void GoToLobby()
    {
        // ∑Œ∫Ò æ¿ ¿Ãµø
    }
    #endregion
}
