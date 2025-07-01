using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Card firstCard;
    public Card secondCard;

    SoundManager_seyun soundManager;
    public AudioClip matchClip;

    public int cardCount = 0;

    float time = 0.0f;
    bool gameStart = false;

    public GameObject endGamePanel;

    private void Awake()
    {
        Time.timeScale = 1.0f;
        Debug.Log($"Time.timeScale = {Time.timeScale}");
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
            GameManager.Instance.time = 0f;
        }
    }

    void Start()
    {
        //soundManager = SoundManager_seyun.Instance;

        //gameStart = true;
        //Time.timeScale = 1.0f;
    }

    void FixedUpdate()
    {
        time += Time.deltaTime;
        Debug.Log($"time = {time}"); 
        if (time >= 5.0f)
        {
            Time.timeScale = 0.0f;
            GameObject.Find("UI").FindChild<UIInGame>().DisplayGameResult(false);
            //endGamePanel.SetActive(true);
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
                GameObject.Find("UI").FindChild<UIInGame>().DisplayGameResult(true);
                Debug.Log("게임 클리어!");
            }
            // 효과음 재생 
            //soundManager.PlayEffectSound(Sound.match);
        }

        // 카드가 서로 일치하지 않으면 
        else
        {
            // 카드 뒤집기
            firstCard.CloseCard();
            secondCard.CloseCard();

            // 효과음 재생
            // soundManager.PlayEffectSound(Sound.flip);
        }

        // 카드 비우기 => 다음 카드를 올리려면 비워야함
        firstCard = null;
        secondCard = null;
    }
}
