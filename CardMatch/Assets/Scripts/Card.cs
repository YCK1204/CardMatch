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
    public void Setting(int number)
    {
        idx = number;
        //frontImage.sprite = Resources.Load<Sprite>($"rtan{idx}"); //sprite �̸� ����
    }

    public void OpenCard()
    {
       // anim.SetBool("IsOpen", true);
        front.SetActive(true);
        back.SetActive(false);

        if (GameManager.Instance.firstCard == null)  // ���� GameManager�� ��� ������ �� �ּ�
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
