using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
  [SerializeField] 
  float groundVelocity = 5f;
  
  [SerializeField]
  Rigidbody2D rigidBody2D;
  private void Update() {
    if (Input.GetKeyDown(KeyCode.A)) {
      var velocity = new Vector2(-groundVelocity, 0);
      rigidBody2D.velocity += velocity;
    } else if (Input.GetKeyUp(KeyCode.A)) {
      var velocity = new Vector2(-groundVelocity, 0);
      rigidBody2D.velocity -= velocity;
      //rigidBody2D.AddForce(force, ForceMode2D.Impulse);
    }
    
    if (Input.GetKeyDown(KeyCode.D)) {
      rigidBody2D.velocity += new Vector2(groundVelocity, 0);
    } else if (Input.GetKeyUp(KeyCode.D)) {
      rigidBody2D.velocity -= new Vector2(groundVelocity, 0);
    }
    
    
  }
}