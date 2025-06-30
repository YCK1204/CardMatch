using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_seyun : MonoBehaviour
{
    public int number;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyCard()
    {
        Invoke("DestroyCardInvoke", 1f);
    }

    void DestroyCardInvoke()
    {
        Destroy(this.gameObject);
    }

    public void CloseCard()
    {
        Invoke("CloseCardInvoke", 1f);
    }

    void CloseCardInvoke()
    {
        Debug.Log("카드 뒤집기");
    }
}
