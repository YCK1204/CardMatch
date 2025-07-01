using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        // �κ� �� �̵�
    }
    public void DisplayGameResult(bool clear)
    {
        var title = GameResultPopup.FindChild<TextMeshProUGUI>(true, name: "Title");
        var result = GameResultPopup.FindChild<TextMeshProUGUI>(true, name: "Result");
        Debug.Log($"{title == null}, {result == null}");
        if (title == null || result == null)
            return;

        title.text = clear ? "���� Ŭ����!" : "���� �й�";
        result.text = clear ? "�����մϴ�!" : "�ٽ� �����غ�����!";
        Time.timeScale = 0f;
        GameResultPopup.SetActive(true);
    }
    public void Retry()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    #endregion
}
