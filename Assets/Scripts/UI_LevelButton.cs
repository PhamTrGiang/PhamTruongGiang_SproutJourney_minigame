using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_LevelButton : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private GameObject iconLock;
    [SerializeField] private Image btnImage;

    [SerializeField] private Sprite btnSpriteDone;
    [SerializeField] private Sprite btnSpritePlay;
    [SerializeField] private Sprite btnSpriteLock;

    private int level;

    private bool isLock = true;

    private void Awake()
    {
        level = transform.GetSiblingIndex() + 1;
    }

    private void OnEnable()
    {
        CheckLock();
    }

    private void CheckLock()
    {
        int levelUnlock = PlayerPrefs.GetInt("Level_Unlock", 1);
        if (level <= levelUnlock)
            isLock = false;
        UpdateUI(isLock, levelUnlock);
    }

    public void PlayLevel()
    {
        if (isLock)
            return;
        GameManager.Instance.LoadLevel(level);
    }

    private void UpdateUI(bool status, int levelUnlock)
    {
        levelText.text = level.ToString();
        levelText.gameObject.SetActive(!status);
        iconLock.SetActive(status);

        if (status == true)
            btnImage.sprite = btnSpriteLock;
        else
        {
            btnImage.sprite = level == levelUnlock ? btnSpritePlay : btnSpriteDone;
        }
    }
}
