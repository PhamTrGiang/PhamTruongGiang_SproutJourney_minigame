using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_LevelHolder : MonoBehaviour
{
    [SerializeField] private GameObject levelButtonPrefab;

    private int maxLevel;

    private void Awake()
    {
        while (transform.childCount > 0)
        {
            Transform child = transform.GetChild(0);
            child.SetParent(null);
            Destroy(child.gameObject);
        }

        maxLevel = SceneManager.sceneCountInBuildSettings - 1;

        GenerateLevelButton();
    }

    private void GenerateLevelButton()
    {
        for (int i = 0; i < maxLevel; i++)
        {
            Instantiate(levelButtonPrefab, transform);
        }
    }
}
