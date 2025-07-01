using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    public void LevelButton(int index)
    {
        
        Level.selectLevelindex = index;
        SceneManager.LoadScene("MainScene");
    }
}
