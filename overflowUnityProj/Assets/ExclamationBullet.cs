using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExclamationBullet : MonoBehaviour
{
    public float lifetime = 3f;

    void Start()
    {
        Destroy(gameObject, lifetime); // Prevent bullets from existing forever
        transform.Rotate(0f, 0f, -90f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Bullet hit: " + other.name);

        if (other.CompareTag("Level"))
        {
            FactorialOverflow factorial = other.GetComponent<FactorialOverflow>();
            if (factorial != null)
            {
                factorial.ApplyOverflow();
            }

            Destroy(gameObject);
        }
    }
}