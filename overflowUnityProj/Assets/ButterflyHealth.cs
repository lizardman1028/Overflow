using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ButterflyHealth : MonoBehaviour
{
    public int maxHealth = 10;  // maximum HP
    public int health = 1;     // current HP, starts at 0
    public AudioSource burstSound;
    public float startingPitch = 1f;
    public float pitchIncreaseAmount = 0.1f;
    private float currentPitch;

    //TEMP!!!
    [SerializeField]
    private FloatLevelController floatLevelController;

    void Start()
    {
        currentPitch = startingPitch;
        burstSound.pitch = currentPitch;
    }

    public void AddHealth(int amount)
    {
        health += amount;
        health = Mathf.Clamp(health, 0, maxHealth);
        Debug.Log("Butterfly health is now: " + health);
        if (health >= maxHealth) {
          health = 1;
          floatLevelController.raiseWater();
          burstSound.pitch = currentPitch;
          burstSound.Play();  
          currentPitch = Mathf.Min(currentPitch + pitchIncreaseAmount);

          DigitBurst digitBurst = GetComponent<DigitBurst>();
          if (digitBurst != null)
          {
              digitBurst.SpawnDigitBurst(transform.position);
          }
        }
    }
}