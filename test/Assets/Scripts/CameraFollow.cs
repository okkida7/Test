using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // The target player object that the camera will follow
    public GameObject player;

    // Speed of the camera's smooth transition to the player's position
    public float smoothSpeed = 0.125f;

    // Speed of the camera's rotation to always face the player
    public float rotationSpeed = 5f;

    void Update()
    {
        // Get the current position of the player
        Vector3 desiredPosition = player.transform.position;

        // Smoothly move the camera's position towards the player's current position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Calculate the rotation that looks at the player
        Quaternion toRotation = Quaternion.LookRotation(player.transform.position - transform.position);

        // Rotate the camera smoothly to always face the player
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
    }
}
