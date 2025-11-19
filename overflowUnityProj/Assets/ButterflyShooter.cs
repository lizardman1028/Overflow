using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyShooter : MonoBehaviour
{
    public GameObject bulletPrefab;      // assign in inspector
    public float shootInterval = 2f;     // seconds between shots
    public float bulletSpeed = 10f;

    private Transform player;
    private float shootTimer = 0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    void Update()
    {
        if (player == null) return;

        shootTimer += Time.deltaTime;

        if (shootTimer >= shootInterval)
        {
            ShootAtPlayer();
            shootTimer = 0f;
        }
    }

    void ShootAtPlayer()
    {
        if (bulletPrefab == null) return;

        // spawn bullet at butterfly position
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        // calculate direction to player
        Vector3 direction = (player.position - transform.position).normalized;

        // set bullet direction
        bullet.GetComponent<bulletEnemy>().SetDirection(direction);
        bullet.GetComponent<bulletEnemy>().speed = bulletSpeed;
    }
}