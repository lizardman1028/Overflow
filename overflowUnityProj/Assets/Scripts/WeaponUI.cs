using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    public Image[] weaponSlots;          // Assign 3 Images in inspector
    public Color lockedColor = Color.gray;
    public Color unlockedColor = Color.white;
    public Color selectedColor = Color.yellow;

    private bool[] unlockedWeapons = new bool[3];
    private int currentWeapon = 0;

    void Start()
    {
        // Initialize all weapons as locked
        for (int i = 0; i < weaponSlots.Length; i++)
        {
            unlockedWeapons[i] = false;
            if (weaponSlots[i] != null)
                weaponSlots[i].color = lockedColor;
        }
    }

    void Update()
    {
        // Change weapon with 1,2,3 keys
        if (Input.GetKeyDown(KeyCode.Alpha1)) SelectWeapon(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SelectWeapon(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) SelectWeapon(2);
    }

    public void UnlockWeapon(int index)
    {
        if (index < 0 || index >= weaponSlots.Length) return;

        unlockedWeapons[index] = true;

        if (weaponSlots[index] != null)
            weaponSlots[index].color = unlockedColor;
    }

    private void SelectWeapon(int index)
    {
        if (index < 0 || index >= weaponSlots.Length) return;
        if (!unlockedWeapons[index]) return;

        currentWeapon = index;

        // Update UI colors
        for (int i = 0; i < weaponSlots.Length; i++)
        {
            if (weaponSlots[i] != null)
            {
                if (i == currentWeapon)
                    weaponSlots[i].color = selectedColor;
                else if (unlockedWeapons[i])
                    weaponSlots[i].color = unlockedColor;
                else
                    weaponSlots[i].color = lockedColor;
            }
        }

        // Here you can trigger weapon switching logic in your player
        Debug.Log("Selected Weapon: " + (currentWeapon + 1));
    }
}