using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelDisplayUI : MonoBehaviour
{
    public TextMeshProUGUI levelText;

    void Start()
    {
        if (levelText == null)
            levelText = GetComponent<TextMeshProUGUI>();

        UpdateLevelText();
    }

    public void UpdateLevelText()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        levelText.text = "Level " + (currentLevel + 1);
    }
}