using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
  [SerializeField] 
  float groundVelocity = 5f;

  [SerializeField]
  private float impulseMagnitudeMovement = 0.5f;

  [SerializeField]
  private float dashForce = 2;
  
  [SerializeField]
  Rigidbody2D rigidBody2D;
  private void Update() {
    
    
  }

  private void FixedUpdate() {
    Vector2 dashDirection = Vector2.zero;
    if (Input.GetKey(KeyCode.A)) {
      // rigidBody2D.velocity = new Vector2(-groundVelocity, 0);
      rigidBody2D.AddForce(Vector2.left * impulseMagnitudeMovement, ForceMode2D.Impulse);
      dashDirection = Vector2.left;
    } 
    
    else if (Input.GetKey(KeyCode.D)) {
      // rigidBody2D.velocity = new Vector2(groundVelocity, 0);
      rigidBody2D.AddForce(Vector2.right * impulseMagnitudeMovement, ForceMode2D.Impulse);
      dashDirection = Vector2.right;
    }
    
    if (Input.GetKey(KeyCode.Space)) {
      rigidBody2D.AddForce(dashDirection * dashForce, ForceMode2D.Force);
        // = new Vector2(groundVelocity * dash, 0);
    }
  }
}