using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody2D rb;
    public float lifetime = 5f;
    public float spriteAngleOffset = -90f; // adjust based on your sprite's direction

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        if (rb.velocity.sqrMagnitude > 0.1f)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle + spriteAngleOffset);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the thing we hit is a butterfly
        if (other.CompareTag("Enemy")) // or "Butterfly" if you have that tag
        {
            ButterflyHealth butterfly = other.GetComponent<ButterflyHealth>();
            if (butterfly != null)
            {
                butterfly.AddHealth(7);
            }

            Destroy(gameObject); // destroy bullet on hit
        }
    }
}