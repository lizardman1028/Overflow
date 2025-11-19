using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButterflyHealth : MonoBehaviour
{
    public int maxHealth = 10;  // maximum HP
    public int health = 1;     // current HP, starts at 0
    public AudioSource burstSound;
    public float startingPitch = 1f;
    public float pitchIncreaseAmount = 0.1f;
    private float currentPitch;


    // Absolutely horrible solution, but don't have time
    public TypewriterText pirateText;
    public int currentLine = 1;
    public string line1 = "Oy there! You one of them travelling medics aren't ya? What are you waiting for, move with A and D to pick up that healing gun of yours and left-click on me to hit me with the good stuff!";
    public string line2 = "Well done! Keep it going! But once I'm healed, I gotta figure out how to exit this area... ";
    public string line3 = "Woah, what just happened?! My health is back down to 1? And those digits, they just exploded out of me?";
    public string line4 = "Is it me, or are the water levels rising? Is this the magical concept of ... INTEGER OVERFLOW!?";
    public string line5 = "Keep raising those water levels bud! Reach the exit and free me from my corporeal self! Ascend!!!";


    private const int TUTORIAL_SCENE_INDEX = 0;
    
    //TEMP!!!
    [SerializeField]
    private FloatLevelController floatLevelController;

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == TUTORIAL_SCENE_INDEX)
        {
            pirateText.ShowText(line1);
            currentLine += 1;
        }
        currentPitch = startingPitch;
        burstSound.pitch = currentPitch;
    }

    public void AddHealth(int amount)
    {
        health += amount;
        health = Mathf.Clamp(health, 0, maxHealth);
        if (health >= 3 && currentLine == 2 && SceneManager.GetActiveScene().buildIndex == TUTORIAL_SCENE_INDEX)
        {
            pirateText.ShowText(line2);
            currentLine += 1;
        }
        Debug.Log("Butterfly health is now: " + health);
        if (health >= maxHealth) {
          health = 1;
          floatLevelController.raiseWater();
          burstSound.pitch = currentPitch;
          burstSound.Play();  
          currentPitch = Mathf.Min(currentPitch + pitchIncreaseAmount);
            if (SceneManager.GetActiveScene().buildIndex == TUTORIAL_SCENE_INDEX)
            {
                if (currentLine == 3)
                {
                    pirateText.ShowText(line3);
                }
                if (currentLine == 4)
                {
                    pirateText.ShowText(line4);
                }
                if (currentLine == 5)
                {
                    pirateText.ShowText(line5);
                }
                currentLine += 1;
            }
            DigitBurst digitBurst = GetComponent<DigitBurst>();
          if (digitBurst != null)
          {
              digitBurst.SpawnDigitBurst(transform.position);
          }
        }
    }
}