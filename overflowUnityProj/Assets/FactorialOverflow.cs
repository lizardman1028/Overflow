using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class FactorialOverflow : MonoBehaviour
{
    public Transform cameraTransform;
    public float shakeDuration = 0.2f;
    public float shakeMagnitude = 0.2f;
    public TextMeshPro levelText;
    public int current = 3;   // starting number (level displayed)

    public AudioSource glitchAudio; // assign a glitch sound in inspector
    public VideoPlayer videoPlayer;

    private int state = 0;    // keeps track of how many hits we've done

    void Start()
    {
        levelText.text = "Level " + current;
    }

    public void ApplyOverflow()
    {
        state++;

        if (state == 1)
        {
            current = 6; // 3! = 6
            levelText.text = "Level " + current;
        }
        else if (state == 2)
        {
            current = 720; // 6! = 720
            levelText.text = "Level " + current;
        }
        else if (state == 3)
        {
            // Fake overflow massive digits
            levelText.text = "Level 26012189435657951002049032270810436111915238261508392047156283910920175638291047562";
        }
        else if (state == 4)
        {
            // Fake overflow massive digits
            levelText.text = "Level 6E111915220394857162039485726????????????????????????????????????????????????????????????????????????????????????????";
        }
        else if (state == 5)
        {
            // Fake overflow massive digits
            levelText.text = "9X!2f#4b@7Q%1&Z*6r^3T~8k$0aL!5m#2j@9p%7y&1s*4w^6d~8v$34f2#9A!b7$X0%k8&Z1@q3*J6^rL9~t24f2#9A!b7$X0%k8&Z1@q3*J6^rL9~t2"; // once beyond insane
        }
        else
        {
            PlayVideo();
        }

        // Play glitch sound
        if (glitchAudio != null)
            glitchAudio.Play();

        StartCoroutine(ShakeCamera());
        StartCoroutine(FlickerText());
    }

    void PlayVideo()
    {
        if (videoPlayer != null)
        {
            videoPlayer.Play();
        }
    }

    // -------------------------------
    // Camera Shake
    // -------------------------------
    IEnumerator ShakeCamera()
    {
        if (cameraTransform == null) yield break;

        Vector3 originalPos = cameraTransform.localPosition;
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * shakeMagnitude;
            float y = Random.Range(-1f, 1f) * shakeMagnitude;
            cameraTransform.localPosition = originalPos + new Vector3(x, y, 0);
            elapsed += Time.deltaTime;
            yield return null;
        }

        cameraTransform.localPosition = originalPos;
    }

    // -------------------------------
    // Text Flicker
    // -------------------------------
    IEnumerator FlickerText()
    {
        TMP_Text text = levelText;
        Color originalColor = text.color;

        int flickerTimes = 12;
        for (int i = 0; i < flickerTimes; i++)
        {
            text.color = new Color(Random.value, Random.value, Random.value);
            yield return new WaitForSeconds(0.05f);
            text.color = originalColor;
            yield return new WaitForSeconds(0.05f);
        }
    }
}