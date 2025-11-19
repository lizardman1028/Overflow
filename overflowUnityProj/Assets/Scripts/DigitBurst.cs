using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigitBurst : MonoBehaviour
{
    public GameObject digitPrefab;       // prefab with SpriteRenderer
    public Sprite[] digitSprites;        // assign 0-9 sprites
    public int burstCount = 10;           // number of digits to spawn
    public float burstForce = 12f;        // how fast they fly out
    public float lifetime = 1.5f;        // destroy after this time

    public void SpawnDigitBurst(Vector3 position)
    {
        for (int i = 0; i < burstCount; i++)
        {
            // Create new digit
            GameObject digit = Instantiate(digitPrefab, position, Quaternion.identity);

            // Randomly choose a sprite
            SpriteRenderer sr = digit.GetComponent<SpriteRenderer>();
            if (sr != null && digitSprites.Length > 0)
                sr.sprite = digitSprites[Random.Range(0, digitSprites.Length)];

            // Random direction
            Vector2 dir = Random.insideUnitCircle.normalized;

            // Add motion
            Rigidbody2D rb = digit.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = dir * burstForce;
            }

            // Destroy after lifetime
            Destroy(digit, lifetime);
        }
    }
}