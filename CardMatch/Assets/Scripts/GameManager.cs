using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Card firstCard;
    public Card secondCard;

    public int cardCount = 0;

    float time = 0.0f;

    public TextMeshProUGUI timeTextUI;
    public TextMeshProUGUI levelTextUI;

    float playTime = 0;
    public int testindex;
    private void Awake()
    {
        testindex = 0;
        Time.timeScale = 1.0f;
        Debug.Log($"Time.timeScale = {Time.timeScale}");

        // MainScene 진입 시 해상도 재설정
        if (GameInitManager.Instance != null)
        {
            GameInitManager.Instance.RefreshDisplaySize();
        }

        levelTextUI.text = $"Lv. {Level.selectLevelindex}";
        playTime = GameInitManager.Instance.GetLevelPlayTime(Level.selectLevelindex);
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        GameManager.Instance.time = 0f;
        GameManager.Instance.timeTextUI = GameObject.Find("UI").FindChild<TextMeshProUGUI>(true, name: "Time");
    }

    void Update()
    {
        GameObject uiObj = GameObject.Find("UI");
        if (uiObj == null)
        {
            return;
        }
        UIInGame uiInGame = uiObj.GetComponentInChildren<UIInGame>(true);
        if (uiInGame == null)
        {
            return;
        }

        time += Time.deltaTime;
        timeTextUI.text = time.ToString("N2");
        Debug.Log($"time = {time}"); 
        if (time >= playTime)
        {
            Time.timeScale = 0.0f;
            GameObject.Find("UI").FindChild<UIInGame>().DisplayGameResult(false);
        }
    }

    public void isMatch()
    {
        // ī�尡 ���� ��ġ�ϸ�
        if (firstCard.idx == secondCard.idx)
        {
            // ī�� �ı�
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            cardCount -= 2;
            if (cardCount == 0) // ���� Ŭ���� ���� ���� ����
            {
                GameObject.Find("UI").FindChild<UIInGame>().DisplayGameResult(true);
                Debug.Log("���� Ŭ����!");
            }
            // ȿ���� ��� 
            //soundManager.PlayEffectSound(Sound.match);
        }

        // ī�尡 ���� ��ġ���� ������ 
        else
        {
            // ī�� ������
            firstCard.CloseCard();
            secondCard.CloseCard();

            // ȿ���� ���
            // soundManager.PlayEffectSound(Sound.flip);
        }

        // ī�� ���� => ���� ī�带 �ø����� �������
        firstCard = null;
        secondCard = null;
    }
}
