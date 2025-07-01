using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Board : MonoBehaviour
{
    public GameObject card;

    public float cardScale = 1.0f;

    void Start()
    {
        int[] hard = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10, 11, 11 };
        cardScale = 0.7f;
        SpawnCard(hard);

        /*switch (Level.selectLevelindex) // Main Scene에서 Stage를 누른 값을 기반으로 카드 생성
        {
            case 1:
                int[] easy = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
                cardScale = 1.0f;
                SpawnCard(easy);
                break;

            case 2:
                int[] normal = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9};
                cardScale = 0.85f;
                SpawnCard(normal);
                break;

            case 3:
                int[] hard = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10, 11, 11}; 
                cardScale = 0.7f;
                SpawnCard(hard);
                break;

        }*/

    }

    void SpawnCard(int[] originalArr)
    {
        int[] arr = originalArr.OrderBy(x => Random.Range(0f, 7f)).ToArray();

        float spacing = 1.4f * cardScale; 
        float xOffset = (4 - 1) * spacing / 2f;
        float yOffset = (arr.Length / 4 - 1) * spacing / 2f;

        for (int i = 0; i < arr.Length; i++)
        {
            Debug.Log($"카드 생성 중: {i} 번째 카드");
            GameObject go = Instantiate(card, this.transform);

            float x = (i % 4) * spacing - xOffset;
            float y = (i / 4) * spacing - yOffset - 2.0f;

            go.transform.position = new Vector2(x, y);
            go.transform.localScale = Vector3.one * cardScale;

            go.GetComponent<Card>().Setting(arr[i]);
        }
        GameManager.Instance.cardCount = arr.Length;
    }
}
