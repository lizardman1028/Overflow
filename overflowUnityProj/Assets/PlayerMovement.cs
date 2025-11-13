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
    if (Input.GetKey(KeyCode.A)) {
      rigidBody2D.velocity = new Vector2(-groundVelocity, 0);;
    } 
    
    else if (Input.GetKey(KeyCode.D)) {
      rigidBody2D.velocity = new Vector2(groundVelocity, 0);
    }

    else {
      rigidBody2D.velocity = new Vector2(0, 0);
    }
    
  }
}