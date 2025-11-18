using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour {
  [SerializeField]
  public List<IBaseWeapon> weapons;

  private int selectedWeapon = 1;

  private void Start() {
    foreach (IBaseWeapon weapon in weapons) {
      weapon.Disable();
    }

    weapons[0].Enable();
  }

  private void EnableWeapon(int i) {
    foreach (IBaseWeapon weapon in weapons) {
      weapon.Disable();
    }
    
    if (i >= weapons.Count) {
      weapons[weapons.Count - 1].Enable();
      return;
    }
    
    weapons[i].Enable();
    return;

  }

  private void Update() {
    if (Input.GetKeyDown(KeyCode.Alpha1)) {
      selectedWeapon = 1;
      EnableWeapon(selectedWeapon - 1);
    }

    if (Input.GetKeyDown(KeyCode.Alpha2)) {
      selectedWeapon = 2;
      EnableWeapon(selectedWeapon - 1);
    }

    if (Input.GetKeyDown(KeyCode.Alpha3)) {
      selectedWeapon = 3;
      EnableWeapon(selectedWeapon - 1);
    }

    if (Input.GetKeyDown(KeyCode.Alpha4)) {
      selectedWeapon = 4;
      EnableWeapon(selectedWeapon - 1);
    }

    if (Input.GetKeyDown(KeyCode.Alpha5)) {
      selectedWeapon = 5;
      EnableWeapon(selectedWeapon - 1);
    }

    if (Input.GetKeyDown(KeyCode.Alpha6)) {
      selectedWeapon = 6;
      EnableWeapon(selectedWeapon - 1);
    }

    if (Input.GetKeyDown(KeyCode.Alpha7)) {
      selectedWeapon = 7;
      EnableWeapon(selectedWeapon - 1);
    }

    if (Input.GetKeyDown(KeyCode.Alpha8)) {
      selectedWeapon = 8;
      EnableWeapon(selectedWeapon - 1);
    }

    if (Input.GetKeyDown(KeyCode.Alpha9)) {
      selectedWeapon = 9;
      EnableWeapon(selectedWeapon - 1);
    }
  }
}