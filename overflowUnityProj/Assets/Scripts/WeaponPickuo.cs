using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour {
  public IBaseWeapon WeaponToGrant;

  public bool shouldBeBow = false;
    public bool shouldBeFact = false;
  // Start is called before the first frame update
  void Start() {
    if (shouldBeBow) {
      WeaponToGrant = FindAnyObjectByType<PlayerBow>();
    }
    if(shouldBeFact)
        {
            WeaponToGrant = FindAnyObjectByType<PlayerFactorial>();
        }
    else {
      WeaponToGrant = FindAnyObjectByType<PlayerGun>();
    }
  }

  // Update is called once per frame
  void Update() { }

  private void OnTriggerEnter2D(Collider2D other) {
    if (other.CompareTag("Player")) {
      if (!other.GetComponent<WeaponSwitcher>().weapons.Contains(WeaponToGrant)) {
        other.GetComponent<WeaponSwitcher>().AddWeapon(WeaponToGrant);
        transform.gameObject.SetActive(false);
      }
    }
  }
}