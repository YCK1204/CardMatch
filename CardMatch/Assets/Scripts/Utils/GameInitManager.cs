using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelInfo
{
    public int levelIndex;
    public float playTime;
}

[System.Serializable]
public class GameData
{
    public List<LevelInfo> levels;
}

public class GameInitManager : MonoBehaviour
{
    public static GameInitManager Instance;
    public GameData gameData;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
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
        SetDisplaySize();
        LoadData();
    }
    private void LoadData()
    {
        try
        {
            // Resources 폴더에서 JSON 파일 로드
            TextAsset jsonFile = Resources.Load<TextAsset>("Data/LevelData");

            if (jsonFile != null)
            {
                // JSON 데이터를 GameData 객체로 역직렬화
                Instance.gameData = JsonUtility.FromJson<GameData>(jsonFile.text);
                Debug.Log($"게임 데이터 로드 완료 - 레벨 수: {Instance.gameData.levels.Count}");

                // 로드된 데이터 확인
                foreach (var level in Instance.gameData.levels)
                {
                    Debug.Log($"레벨 {level.levelIndex}, 플레이 타임 {level.playTime}");
                }
            }
            else
            {
                Debug.LogError("LevelData.json 파일을 찾을 수 없습니다!");
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError($"게임 데이터 로드 실패: {e.Message}");
        }
    }
    private void SetDisplaySize()
    {
        // 모바일 기기 해상도 조절
        float targetAspect = 9.0f / 16.0f; // 목표 비율 (9:16)
        float currentAspect = (float)Screen.width / Screen.height;
        
        // 현재 화면 비율이 목표 비율과 다른 경우 조절
        if (currentAspect >= targetAspect)
        {
            // 화면이 더 넓은 경우 (좌우 여백 생성)
            int newWidth = Mathf.RoundToInt(Screen.height * targetAspect);
            Screen.SetResolution(newWidth, Screen.height, true);
        }
        else
        {
            // 화면이 더 좁은 경우 (상하 여백 생성)
            int newHeight = Mathf.RoundToInt(Screen.width / targetAspect);
            Screen.SetResolution(Screen.width, newHeight, true);
        }
        
        // FPS 제한 설정 (모바일 최적화)
        Application.targetFrameRate = 60;
        
        Debug.Log($"Display Size Set - Resolution: {Screen.width}x{Screen.height}, Aspect: {(float)Screen.width/Screen.height:F2}");
    }
    public float GetLevelPlayTime(int levelIndex)
    {
        try
        {
            foreach (var level in Instance.gameData.levels)
            {
                if (level.levelIndex == levelIndex)
                {
                    return level.playTime;
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError($"레벨 플레이 타임 조회 실패: {e.Message}");
        }
        return 0; // 해당 레벨이 없을 경우 기본값 반환
    }
}
