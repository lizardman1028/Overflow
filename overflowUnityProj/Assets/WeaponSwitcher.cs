using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour {
  public List<int> test;
  [SerializeField]
  public List<IBaseWeapon> weapons;
  private int selectedWeapon = 0;

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

    if (i < weapons.Count) { 
      weapons[i].Enable();
    }
    else {
      weapons[weapons.Count - 1].Enable();
    }
   
  }
  private void Update() {
    if (Input.GetKeyDown(KeyCode.Alpha1)) {
      selectedWeapon = 1;
    } 
    if (Input.GetKeyDown(KeyCode.Alpha2)) {
      selectedWeapon = 2;
    } 
    if (Input.GetKeyDown(KeyCode.Alpha3)) {
      selectedWeapon = 3;
    } 
    if (Input.GetKeyDown(KeyCode.Alpha4)) {
      selectedWeapon = 4;
    } 
    if (Input.GetKeyDown(KeyCode.Alpha5)) {
      selectedWeapon = 5;
    } 
    if (Input.GetKeyDown(KeyCode.Alpha6)) {
      selectedWeapon = 6;
    } 
    if (Input.GetKeyDown(KeyCode.Alpha7)) {
      selectedWeapon = 7;
    } 
    if (Input.GetKeyDown(KeyCode.Alpha8)) {
      selectedWeapon = 8;
    } 
    if (Input.GetKeyDown(KeyCode.Alpha9)) {
      selectedWeapon = 9;
    } 
    EnableWeapon(selectedWeapon);
  }
}
