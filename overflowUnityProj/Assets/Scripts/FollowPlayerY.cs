using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerY : MonoBehaviour
{
    public Transform player;    // Drag your Player object here in Inspector
    public float yOffset = 2f;  // If you want the pirate slightly above/below

    void Update()
    {
        transform.position = new Vector3(
            transform.position.x,       // keep pirate’s original X
            player.position.y + yOffset, // match player Y
            transform.position.z        // keep pirate’s original Z
        );
    }
}