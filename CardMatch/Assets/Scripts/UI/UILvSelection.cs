using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UILvSelection : MonoBehaviour
{
    [SerializeField]
    GameObject Popup;
    public void OnClickLevel()
    {
        GameObject clickedButton = EventSystem.current.currentSelectedGameObject;

        if (clickedButton != null)
        {
            TextMeshProUGUI lvText = clickedButton.GetComponentInChildren<TextMeshProUGUI>();
            if (lvText == null)
                return;

            int lv = int.Parse(lvText.text.Substring(5));
            Time.timeScale = 1f; // 게임 속도 초기화
            Debug.Log($"레벨 {lv}");
            SceneManager.LoadScene("MainScene"); // 레벨에 맞는 씬 전환 필요
        }
    }
    public void ClosePopup()
    {
        Popup.SetActive(false);
    }
}
