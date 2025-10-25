using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private GameObject Menu_UI;
    [SerializeField] private GameObject LevelSelection_UI;
    [SerializeField] private GameObject Game_UI;

    public static UI_Manager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else Destroy(gameObject);

        DisableAllUI();
        Menu_UI.SetActive(true);
    }

    public void DisableAllUI()
    {
        Menu_UI.SetActive(false);
        LevelSelection_UI.SetActive(false);
        Game_UI.SetActive(false);
    }

    public void ActiveLevelSelection()
    {
        DisableAllUI();
        LevelSelection_UI.SetActive(true);
    }

    public void BackToMenu()
    {
        DisableAllUI();
        Menu_UI.SetActive(true);
        GameManager.Instance.EnableBackground(true);
    }

    public void ActiveGame()
    {
        DisableAllUI();
        Game_UI.SetActive(true);
    }
}