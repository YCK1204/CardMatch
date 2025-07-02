using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    float shortestTime = 0f;

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
        //Debug.Log($"time = {time}"); 
        if (time >= playTime)
        {
            Time.timeScale = 0.0f;
            GameObject.Find("UI").FindChild<UIInGame>().DisplayGameResult(false);
        }
    }

    public void isMatch()
    {
        // 카드가 서로 일치하면
        if (firstCard.idx == secondCard.idx)
        {
            // 카드 파괴
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            cardCount -= 2;
            if (cardCount == 0) // 게임 클리어 사진 넣을 예정
            {
                //GameObject.Find("UI").FindChild<UIInGame>().DisplayGameResult(true);
                Debug.Log("게임 클리어!");

                // 승리 UI 활성화
                GameObject.Find("UI").FindChild<UIInGame>().Finish();

                // 시간 표시
                if (PlayerPrefs.HasKey("shortestTime"))
                {
                    Debug.Log("키 존재함!");
                    shortestTime = PlayerPrefs.GetFloat("shortestTime");
                    if (time < shortestTime)
                    {
                        PlayerPrefs.SetFloat("shortestTime", time);
                        shortestTime = time;
                    }
                }
                else
                {
                    Debug.Log("키 존재하지 않음!");
                    PlayerPrefs.SetFloat("shortestTime", time);
                    shortestTime = time;
                }

                GameObject.Find("UI").FindChild<UIInGame>().shortestTime().text = shortestTime.ToString();

                // 사진 활성화
                GameObject.Find("UI").FindChild<UIInGame>().winners()[Random.Range(0, 5)].SetActive(true);
            }
        }

        // 카드가 서로 일치하지 않으면
        else
        {
            // 카드 뒤집기
            firstCard.CloseCard();
            secondCard.CloseCard();
        }

        // 카드 비우기 => 다음 카드를 올리려면 비워야함
        firstCard = null;
        secondCard = null;
    }
}
