using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHPDisplayUI : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public RectTransform hpBarFill;       // UI panel that fills the bar
    public TextMeshProUGUI hpText;

    private Vector2 originalSize;

    void Start()
    {
        if (playerHealth == null)
            playerHealth = FindObjectOfType<PlayerHealth>();

        if (hpBarFill != null)
            originalSize = hpBarFill.sizeDelta;
    }

    void Update()
    {
        if (playerHealth == null || hpBarFill == null) return;

        float healthPercent = (float)playerHealth.currentHealth / playerHealth.maxHealth;

        // Shrink bar horizontally
        hpBarFill.sizeDelta = new Vector2(originalSize.x * healthPercent, originalSize.y);

        if (hpText != null)
            hpText.text = $"{playerHealth.currentHealth} / {playerHealth.maxHealth}";
    }
}