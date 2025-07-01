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
            Time.timeScale = 1f; // ���� �ӵ� �ʱ�ȭ
            Debug.Log($"���� {lv}");
            SceneManager.LoadScene("MainScene"); // ������ �´� �� ��ȯ �ʿ�
        }
    }
    public void ClosePopup()
    {
        Popup.SetActive(false);
    }
}
