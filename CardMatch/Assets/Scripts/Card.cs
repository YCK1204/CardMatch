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
        frontImage.sprite = Resources.Load<Sprite>($"Sprites/fruit{idx}");  //sprite 이름 통일

    }

    public void OpenCard()
    {
        //audioSource.volume = AudioManager.Instance.GetSfxVolume();
        //audioSource.PlayOneShot(clip);

        // anim.SetBool("IsOpen", true);
        front.SetActive(true);
        back.SetActive(false);

        if (GameManager.Instance.firstCard == null)  // 현재 GameManager이 없어서 오류가 떠 주석
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
       // anim.SetBool("IsOpen", false);
        front.SetActive(false);
        back.SetActive(true);
    }
}
