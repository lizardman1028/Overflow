using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndDoor : MonoBehaviour
{
    private ScreenFade fadeController;

    private void Start()
    {
        fadeController = FindObjectOfType<ScreenFade>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            fadeController.FadeAndLoadNextLevel();
        }
    }
}