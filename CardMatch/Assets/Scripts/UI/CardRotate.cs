using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardRotate : MonoBehaviour
{
    public GameObject cardFront; // ī�� �ո�
    public GameObject cardBack;  // ī�� �޸�
    
    public Image ctimage; 

    float rotationScale = 0f;    
    int ImageIndex = 0; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotationScale = cardBack.transform.localScale.x;

        if (rotationScale <= 0.5f)
        {
            cardFront.SetActive(true); // ī�� �ո� Ȱ��ȭ
            cardBack.SetActive(false);  // ī�� �޸� ��Ȱ��ȭ
            cardFront.transform.localScale = new Vector3(1f - rotationScale, 1f, 1f);
        }
        else
        {
            cardFront.SetActive(false); // ī�� �ո� ��Ȱ��ȭ
            cardBack.SetActive(true);  // ī�� �޸� Ȱ��ȭ
        }
    }

    public void ChangeImage()
    {
        ImageIndex = (ImageIndex + 1) % 5; // �ٽ� 0���� �����Ϸ��� %�� ������ ���� �������
        ctimage.sprite = Resources.Load<Sprite>($"cardUI/card{ImageIndex}"); // cardUI���� ���� �����鿡 ����
    }
}
