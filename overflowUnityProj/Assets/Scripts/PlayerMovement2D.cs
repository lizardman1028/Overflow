using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{

    [Header("Movement Settings")]
    public float moveSpeed = 5f;          // Normal movement speed
    public float dashDistance = 2f;       // How far the dash moves
    public float dashCooldown = 0.5f;     // Cooldown between dashes

    private Vector3 moveDirection = Vector3.zero;
    private float lastDashTime = -Mathf.Infinity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 1️⃣ Read input
        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.A)) moveX = -1f;
        if (Input.GetKey(KeyCode.D)) moveX = 1f;
        if (Input.GetKey(KeyCode.W)) moveY = 1f;
        if (Input.GetKey(KeyCode.S)) moveY = -1f;

        moveDirection = new Vector3(moveX, moveY, 0f).normalized;

        // 2️⃣ Move player
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // 3️⃣ Dash
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= lastDashTime + dashCooldown)
        {
            transform.position += moveDirection * dashDistance;
            lastDashTime = Time.time;
        } 
    }
}
