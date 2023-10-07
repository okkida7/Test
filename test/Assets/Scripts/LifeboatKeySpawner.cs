using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeboatKeySpawner : MonoBehaviour
{
    public GameObject lifeboatKeyPrefab;
    public float checkRadius = 0.5f;
    public Vector3 minBounds;
    public Vector3 maxBounds;
    void Start()
    {
        Vector3 randomPosition = GetRandomPositionAvoidingWalls();
        // Instantiate the lifeboat key at the random position
        Instantiate(lifeboatKeyPrefab, randomPosition, Quaternion.identity);
    }
    Vector3 GetRandomPositionAvoidingWalls()
    {
        Vector3 randomPosition;
        // Set a max attempt count to avoid potential infinite loop
        int maxAttempts = 100;  
        int currentAttempt = 0;

        // Generate a random position within the bounds
        do
        {
            randomPosition = new Vector3(
                Random.Range(minBounds.x, maxBounds.x),
                Random.Range(minBounds.y, maxBounds.y),
                Random.Range(minBounds.z, maxBounds.z)
            );

            currentAttempt++;

            if (currentAttempt > maxAttempts)
            {
                Debug.LogWarning("Max attempts reached! Consider expanding your spawn area or reducing objects.");
                break;
            }
        }

        // Check if the random position is within the bounds and not colliding with any objects
        while (Physics.CheckSphere(randomPosition, checkRadius, 1 << LayerMask.NameToLayer("Obstacle")));

        return randomPosition;
    }

    // Draw the bounds in the editor
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube((minBounds + maxBounds) / 2, maxBounds - minBounds);
    }
}
