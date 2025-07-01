using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardRotate : MonoBehaviour
{
    public GameObject cardFront; // 카드 앞면
    public GameObject cardBack;  // 카드 뒷면
    
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
            cardFront.SetActive(true); // 카드 앞면 활성화
            cardBack.SetActive(false);  // 카드 뒷면 비활성화
            cardFront.transform.localScale = new Vector3(1f - rotationScale, 1f, 1f);
        }
        else
        {
            cardFront.SetActive(false); // 카드 앞면 비활성화
            cardBack.SetActive(true);  // 카드 뒷면 활성화
        }
    }

    public void ChangeImage()
    {
        ImageIndex = (ImageIndex + 1) % 5; // 다시 0부터 시작하려고 %로 나머지 연산 사용했음
        ctimage.sprite = Resources.Load<Sprite>($"cardUI/card{ImageIndex}"); // cardUI폴더 안의 사진들에 접근
    }
}
