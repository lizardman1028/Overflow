using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : IBaseWeapon
{
    public GameObject bulletPrefab;  // Assign your bullet prefab in Inspector
    public float bulletSpeed = 10f;

    public void Enable() {
      this.enabled = true;
    }
    
    public void Disable() {
      this.enabled = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left click
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // 1. Create a bullet at player's position
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        // 2. Get mouse position in world space
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f; // Remove z offset

        // 3. Compute direction from player to mouse
        Vector2 direction = (mousePos - transform.position).normalized;

        // 4. Set bullet velocity
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = direction * bulletSpeed;

        // 5. Optional: rotate bullet to face direction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}