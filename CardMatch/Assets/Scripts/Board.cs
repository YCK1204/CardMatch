using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Board : MonoBehaviour
{
    public GameObject card;

    void Start()
    {
        switch (Level.selectLevelindex) // Main Scene에서 Stage를 누른 값을 기반으로 카드 생성
        {
            case 1:
                int[] easy = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
                SpawnCard(easy);
                break;

            case 2:
                int[] normal = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 0, 0, 1, 1 }; //카드 나오는지 테스트 배열 추후 8번과 9번으로 바꿔야함
                SpawnCard(normal);
                break;

            case 3:
                int[] hard = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 0, 0, 1, 1, 2, 2, 3, 3 }; // 위와동일
                SpawnCard(hard);
                break;

        }

    }

    void SpawnCard(int[] originalArr)
    {
        int[] arr = originalArr.OrderBy(x => Random.Range(0f, 7f)).ToArray();

        for (int i = 0; i < arr.Length; i++)
        {
            GameObject go = Instantiate(card, this.transform);

            float x = (i % 4) * 1.4f - 2.1f;
            float y = (i / 4) * 1.4f - 4.0f;

            go.transform.position = new Vector2(x, y);
            go.GetComponent<Card>().Setting(arr[i]);
        }

<<<<<<< Updated upstream
        GameManager.Instance.cardCount = arr.Length;
=======
        //GameManager.instance.cardCount = arr.Length;
>>>>>>> Stashed changes
    }
}
