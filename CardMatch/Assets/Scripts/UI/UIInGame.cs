using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIInGame : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI PlayTime;
    [SerializeField]
    GameObject PausePopup;
    [SerializeField]
    TextMeshProUGUI TextLv;
    [SerializeField]
    GameObject GameResultPopup;
    [SerializeField]
    GameObject SuccessPopup;
    [SerializeField]
    Text shortestTimeUI;
    [SerializeField]
    GameObject[] winnersArray;

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
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartScene");
    }
    public void DisplayGameResult(bool clear)
    {
        var title = GameResultPopup.FindChild<TextMeshProUGUI>(true, name: "Title");
        var result = GameResultPopup.FindChild<TextMeshProUGUI>(true, name: "Result");
        Debug.Log($"{title == null}, {result == null}");
        if (title == null || result == null)
            return;

        title.text = clear ? "게임 클리어!" : "게임 패배";
        result.text = clear ? "축하합니다!" : "다시 도전해보세요!";
        Time.timeScale = 0f;
        GameResultPopup.SetActive(true);
    }
    public void Finish()
    {
        SuccessPopup.SetActive(true);
    }
    public Text shortestTime()
    {
        return shortestTimeUI;
    }
    public GameObject[] winners()
    {
        return winnersArray;
    }
    public void Retry()
    {
        Time.timeScale = 1f;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    #endregion
}
