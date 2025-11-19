using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactorialWeaponObject : MonoBehaviour
{
    [Header("Hit Settings")]
    public int hitsRequired = 8;
    private int currentHits = 0;

    [Header("Physics Settings")]
    public Rigidbody2D rb;           // Rigidbody2D on the object
    public Collider2D pickupCollider; // Collider used for player pickup
    public float fallForce = 5f;      // Optional: add a little nudge when it falls

    [Header("Pickup Settings")]
    public string weaponName = "FactorialGun"; // Name of the weapon added to the player

    private bool isDropped = false;

    void Start()
    {
        if (rb == null) rb = GetComponent<Rigidbody2D>();
        if (pickupCollider == null) pickupCollider = GetComponent<Collider2D>();

        // Start as kinematic and non-pickupable
        rb.isKinematic = true;
        pickupCollider.enabled = false;
    }

    public void Hit()
    {
        if (isDropped) return;

        currentHits++;
        Debug.Log("Factorial weapon hit! " + currentHits + "/" + hitsRequired);

        if (currentHits >= hitsRequired)
        {
            DropWeapon();
        }
    }

    void DropWeapon()
    {
        isDropped = true;
        rb.isKinematic = false;
        rb.AddForce(Vector2.down * fallForce, ForceMode2D.Impulse); // optional nudge
        pickupCollider.enabled = true;

        Debug.Log("Factorial weapon dropped! Player can now pick it up.");
    }

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isDropped) return;

        if (collision.CompareTag("Player"))
        {
            // Here you would give the weapon to the player
            Debug.Log("Player picked up the " + weaponName + "!");

            // Example: call a method on your player script
            PlayerWeaponController playerWeapons = collision.GetComponent<PlayerWeaponController>();
            if (playerWeapons != null)
            {
                playerWeapons.UnlockWeapon(weaponName);
            }

            Destroy(gameObject);
        }
    }
    */
}
