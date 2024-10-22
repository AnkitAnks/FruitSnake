using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamer : MonoBehaviour
{
    public Transform target;       // The target (player) to follow
    public Vector3 offset;         // Offset behind the player
    public float smoothSpeed = 0.125f; // Speed for smooth camera transition

    void FixedUpdate()
    {
        // Calculate the position behind the player based on their rotation
        Vector3 desiredPosition = target.position + target.rotation * offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Keep the camera always facing the back of the player
        transform.LookAt(target.position + Vector3.up * 1.5f); // Adjust the look height slightly above player
    }
}
