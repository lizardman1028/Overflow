using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatLevelController : MonoBehaviour {
  [SerializeField]
  private Transform playerPlusWater;

  private void Update() {
    if (Input.GetKeyDown(KeyCode.Space) && false) {
      var goUpVector = Vector3.up;
      playerPlusWater.transform.position += 1f * goUpVector;
    }
  }
  
  public void raiseWater() {
    var goUpVector = Vector3.up;
    playerPlusWater.transform.position += 1f * goUpVector;
  }
}