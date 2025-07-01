using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    AudioSource audioSource;
    public AudioClip clip;

    public Card firstCard;
    public Card secondCard;

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
            GameManager.Instance.time = 0f;
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameStart = true;
        Time.timeScale = 1.0f;
    }

    void FixedUpdate()
    {
        if (gameStart)
        {
            time += Time.deltaTime;
            if (time >= 5.0f)
            {
                Time.timeScale = 0.0f;
                GameObject.Find("UI").FindChild<UIInGame>().DisplayGameResult(false);
                //endGamePanel.SetActive(true);
            }
        }
    }

    public void isMatch()
    {
        // ī�尡 ���� ��ġ�ϸ�
        if(firstCard.idx == secondCard.idx)
        {
            // ī�� �ı�
            audioSource.volume = AudioManager.Instance.GetSfxVolume();
            audioSource.PlayOneShot(clip);

            firstCard.DestroyCard();
            secondCard.DestroyCard();
            cardCount -= 2;
            if(cardCount == 0) // ���� Ŭ���� ���� ���� ����
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
