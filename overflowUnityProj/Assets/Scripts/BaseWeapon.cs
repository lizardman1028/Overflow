using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IBaseWeapon : MonoBehaviour {
  public void Enable() {
    this.enabled = true;
  }

  public void Disable() {
    this.enabled = false;
  }
}
