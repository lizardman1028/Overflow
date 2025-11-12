using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 3f;

    void Start()
    {
        Destroy(gameObject, lifetime); // Prevent bullets from existing forever
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the thing we hit is a butterfly
        if (other.CompareTag("Enemy")) // or "Butterfly" if you have that tag
        {
            ButterflyHealth butterfly = other.GetComponent<ButterflyHealth>();
            if (butterfly != null)
            {
                butterfly.AddHealth(1);
            }

            Destroy(gameObject); // destroy bullet on hit
        }
    }
}