using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Card_seyun firstCard;
    public Card_seyun secondCard;

    SoundManager_seyun soundManager;
    public AudioClip matchClip;

    float time = 0.0f;
    bool gameStart = false;

    public GameObject endGamePanel;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        soundManager = SoundManager_seyun.Instance;

        gameStart = true;
        Time.timeScale = 1.0f;
    }

    void Update()
    {
        if (gameStart)
        {
            time += Time.deltaTime;
            if (time >= 30.0f)
            {
                Time.timeScale = 0.0f;
                endGamePanel.SetActive(true);
            }
        }
    }

    public void isMatch()
    {
        // 카드가 서로 일치하면
        if(firstCard.number == secondCard.number)
        {
            // 카드 파괴
            firstCard.DestroyCard();
            secondCard.DestroyCard();

            // 효과음 재생 
            soundManager.PlayEffectSound(Sound.match);
        }

        // 카드가 서로 일치하지 않으면 
        else
        {
            // 카드 뒤집기
            firstCard.CloseCard();
            secondCard.CloseCard();

            // 효과음 재생
            soundManager.PlayEffectSound(Sound.flip);
        }

        // 카드 비우기 => 다음 카드를 올리려면 비워야함
        firstCard = null;
        secondCard = null;
    }
}
