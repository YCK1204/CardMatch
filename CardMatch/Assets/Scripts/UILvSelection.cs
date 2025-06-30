using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UILvSelection : MonoBehaviour
{
    public void OnClickLevel()
    {
        GameObject clickedButton = EventSystem.current.currentSelectedGameObject;

        if (clickedButton != null)
        {
            TextMeshProUGUI lvText = clickedButton.GetComponentInChildren<TextMeshProUGUI>();
            if (lvText == null)
                return;

            int lv = int.Parse(lvText.text.Substring(5));
            Debug.Log($"���� {lv}");
            // ������ �´� �� ��ȯ �ʿ�
        }
    }
}
