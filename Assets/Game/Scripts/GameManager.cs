using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public string battleSceneName;

    private string previousSceneName;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartBattle()
    {
        SaveSystem.SavePlayerData(new PlayerData(Player.Instance));
        LoadScene(battleSceneName);
    }

    public void BackToPreviousScene()
    {
        LoadScene(previousSceneName);
    }

    private void LoadScene(string sceneName)
    {
        previousSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
