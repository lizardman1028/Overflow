using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public PlayerGun playerGun; // assign your PlayerGun object here

    public void ShowGameOver()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f; // stops gameplay

        // Disable shooting
        if (playerGun != null)
        {
            playerGun.canShoot = false;
            playerGun.Disable();
        }
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}