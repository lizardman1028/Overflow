using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenFade : MonoBehaviour
{
    public CanvasGroup fadeGroup;
    public float fadeDuration = 1f;
    public TMPro.TextMeshProUGUI levelText;

    void Start()
    {
        fadeGroup.alpha = 0f;

        if (levelText != null)
        {
            // Make sure text starts invisible
            var c = levelText.color;
            c.a = 0f;
            levelText.color = c;
        }
    }

    public void FadeAndLoadNextLevel()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        if (levelText != null)
        {
            levelText.text = "Level " + nextScene.ToString();
        }

        StartCoroutine(FadeOut());
    }

    private System.Collections.IEnumerator FadeOut()
    {
        float t = 0f;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Clamp01(t / fadeDuration);

            fadeGroup.alpha = alpha;

            // ⭐ Add this to fade the text along with black overlay
            if (levelText != null)
            {
                var c = levelText.color;
                c.a = alpha;
                levelText.color = c;
            }

            yield return null;
        }

        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextScene);
    }
}