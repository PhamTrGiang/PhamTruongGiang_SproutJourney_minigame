using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private GameObject disableWhenPlay;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject lostPanel;

    [SerializeField] private TextMeshProUGUI levelText;

    private int point;
    private int currentLevel = 0;
    private int maxLevel;
    private int currentLevelUnlock;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        Application.targetFrameRate = 60;

        if (Instance == null)
            Instance = this;
        else Destroy(gameObject);

        currentLevelUnlock = PlayerPrefs.GetInt("Level_Unlock", 1);
        maxLevel = SceneManager.sceneCountInBuildSettings - 1;
    }

    public void LoadLevel(int level)
    {
        DisableAllPanel();
        UI_Manager.Instance.ActiveGame();
        EnableBackground(false);
        levelText.text = "Level " + level;

        if (currentLevel != 0)
            SceneManager.UnloadSceneAsync(currentLevel);

        currentLevel = level;
        SceneManager.LoadSceneAsync(level, LoadSceneMode.Additive);
    }

    public void Menu()
    {
        SceneManager.UnloadSceneAsync(currentLevel);
        currentLevel = 0;
        UI_Manager.Instance.BackToMenu();
    }

    public void GetPoint()
    {
        point = FindObjectsByType<Apple>(FindObjectsSortMode.None).Length;

        if (point > 0)
            point--;
        if (point <= 0)
            WinLevel();
    }

    private void WinLevel()
    {
        winPanel.SetActive(true);
        if (currentLevelUnlock > maxLevel)
            return;
        currentLevelUnlock++;
        PlayerPrefs.SetInt("Level_Unlock", currentLevelUnlock);
    }
    public void LostLevel()
    {
        lostPanel.SetActive(true);
    }

    public void LoadNextLevel()
    {
        int nextLevel = currentLevel >= maxLevel ? currentLevel : currentLevel + 1;
        LoadLevel(nextLevel);
    }

    public void ReloadLevel()
    {
        LoadLevel(currentLevel);
    }

    public void EnableBackground(bool status) => disableWhenPlay.SetActive(status);

    private void DisableAllPanel()
    {
        winPanel.SetActive(false);
        lostPanel.SetActive(false);
    }
}