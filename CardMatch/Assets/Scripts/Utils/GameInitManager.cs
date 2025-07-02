using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitManager : MonoBehaviour
{
    public static GameInitManager _instance;
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeGame();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void InitializeGame()
    {
        // Add your game initialization logic here
        Debug.Log("Game Initialized");
    }
    private void LoadData()
    {

    }
    private void SetDisplaySize()
    {
        
    }
}
