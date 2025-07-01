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
        // ī�尡 ���� ��ġ�ϸ�
        if(firstCard.idx == secondCard.idx)
        {
            // ī�� �ı�
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            cardCount -= 2;
            if(cardCount == 0) // ���� Ŭ���� ���� ���� ����
            {
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
