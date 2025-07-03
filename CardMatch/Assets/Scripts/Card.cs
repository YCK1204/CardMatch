using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int idx = 0;

    public GameObject front;
    public GameObject back;
    public Animator anim;
    public SpriteRenderer frontImage;
    AudioSource audioSource;
    public AudioClip clip;

    public void Setting(int number)
    {
        audioSource = GetComponent<AudioSource>();
        idx = number;
        frontImage.sprite = Resources.Load<Sprite>($"Sprites/fruit{idx}");  

    }

    public void OpenCard()
    {
        if (GameManager.Instance.isProcessing)
            return;

        if (front.activeSelf)
            return;

        Board board = FindObjectOfType<Board>();
        if (board.isSetting)
            return;


        //audioSource.volume = AudioManager.Instance.GetSfxVolume();
        //audioSource.PlayOneShot(clip);

        front.SetActive(true);
        back.SetActive(false);

        if (GameManager.Instance.firstCard == null)  
        {
            GameManager.Instance.firstCard = this;
        }
        else
        {
            GameManager.Instance.secondCard = this;
            GameManager.Instance.isMatch();
        }
    }
    public void DestroyCard()
    {
        Invoke("DestoryCardInvoke", 0.5f);
    }
    void DestoryCardInvoke()
    {
        Destroy(gameObject);
    }

    public void CloseCard()
    {
        Invoke("CloseCardInvoke", 0.5f);
    }

    void CloseCardInvoke()
    {
        front.SetActive(false);
        back.SetActive(true);
    }
}
