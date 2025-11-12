using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ButterflyHealth : MonoBehaviour
{
    public int maxHealth = 10;  // maximum HP
    public int health = 1;     // current HP, starts at 0
    public void AddHealth(int amount)
    {
        health += amount;
        health = Mathf.Clamp(health, 0, maxHealth);
        Debug.Log("Butterfly health is now: " + health);
    }
}