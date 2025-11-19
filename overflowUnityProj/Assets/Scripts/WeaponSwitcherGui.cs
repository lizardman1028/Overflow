using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitcherGui : MonoBehaviour {
  public Image gun;
  public Image bow;
  public Image factorial;
  private WeaponSwitcher weaponSwitcher;
  
  
  // Start is called before the first frame update
  void Start() {
    weaponSwitcher = FindAnyObjectByType<WeaponSwitcher>();
  }

  // Update is called once per frame
  void Update() {
    
    if (weaponSwitcher.weapons.Count >= 1) {
      gun.color = Color.white;
      if (weaponSwitcher.selectedWeapon == 1) {
        gun.color = Color.black;
      }
    }
    else {
      gun.color = Color.clear;
    }

    if (weaponSwitcher.weapons.Count >= 2) {
      bow.color = Color.white;
      if (weaponSwitcher.selectedWeapon == 2) {
        bow.color = Color.black;
      }
    }
    else {
      bow.color = Color.clear;
    }

    if (weaponSwitcher.weapons.Count >= 3) {
      factorial.color = Color.white;
    }
    else {
      factorial.color = Color.clear;
    }
  }
}