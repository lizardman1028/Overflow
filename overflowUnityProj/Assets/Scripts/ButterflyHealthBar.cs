using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButterflyHealthBar : MonoBehaviour
{
    public Transform fill; // assign the Fill child here
    public ButterflyHealth butterfly;

    public Vector3 offset = new Vector3(-2f, -2f, 0); // position above the butterfly

    void Update()
    {
        if (butterfly != null)
        {
            // Make the bar follow the butterfly
            transform.position = butterfly.transform.position + offset;

            // Scale the fill based on HP (assuming max HP = 10)
            float fillAmount = Mathf.Clamp01((float)butterfly.health / butterfly.maxHealth);
            fill.localScale = new Vector3(fillAmount * 2, 0.5f, 1f);

            // Optional: keep rotation fixed
            transform.rotation = Quaternion.identity;
        }
    }
}