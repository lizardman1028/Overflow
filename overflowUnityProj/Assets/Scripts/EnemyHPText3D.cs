using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyHPText3D : MonoBehaviour
{
    public ButterflyHealth enemyHealth;  // your enemy HP script
    public Vector3 offset = new Vector3(0, 2f, 0); // position above enemy
    public Camera mainCamera;

    private TextMeshPro textMesh;

    void Start()
    {
        if (enemyHealth == null)
            enemyHealth = GetComponentInParent<ButterflyHealth>();

        if (mainCamera == null)
            mainCamera = Camera.main;

        textMesh = GetComponent<TextMeshPro>();
    }

    void LateUpdate()
    {
        if (enemyHealth == null || textMesh == null) return;

        // Update text
        textMesh.text = $"{enemyHealth.health} / {enemyHealth.maxHealth}";

        // Follow enemy position
        transform.position = enemyHealth.transform.position + offset;

        // Face the camera
        transform.rotation = Quaternion.LookRotation(transform.position - mainCamera.transform.position);
    }
}