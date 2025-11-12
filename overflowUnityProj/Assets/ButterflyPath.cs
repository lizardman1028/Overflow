using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyPath : MonoBehaviour
{
    [Header("Path Settings")]
    public Transform[] waypoints;   // Set these in the Inspector
    public float speed = 3f;
    public bool loop = true;        // Should it loop back to start?

    private int current = 0;

    void Update()
    {
        if (waypoints.Length == 0) return;

        // Move toward the current waypoint
        Transform target = waypoints[current];
        transform.position = Vector2.Lerp(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        // Check if we reached it
        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            if (current < waypoints.Length - 1)
                current++;
            else if (loop)
                current = 0;
        }
    }

    // Draw lines in Scene view so you can see the path
    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        for (int i = 0; i < waypoints.Length - 1; i++)
        {
            if (waypoints[i] && waypoints[i + 1])
                Gizmos.DrawLine(waypoints[i].position, waypoints[i + 1].position);
        }
    }
}