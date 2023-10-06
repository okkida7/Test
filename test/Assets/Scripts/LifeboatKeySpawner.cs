using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeboatKeySpawner : MonoBehaviour
{
    public GameObject lifeboatKeyPrefab;
    public float checkRadius = 0.5f;
    public Vector3 minBounds;
    public Vector3 maxBounds;
    void Awake()
    {
        Vector3 randomPosition = GetRandomPositionAvoidingWalls();
        Instantiate(lifeboatKeyPrefab, randomPosition, Quaternion.identity);
    }
    Vector3 GetRandomPositionAvoidingWalls()
    {
        Vector3 randomPosition;
        int maxAttempts = 100;  // Set a max attempt count to avoid potential infinite loop
        int currentAttempt = 0;

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
        while (Physics.CheckSphere(randomPosition, checkRadius, 1 << LayerMask.NameToLayer("Obstacle")));

        return randomPosition;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube((minBounds + maxBounds) / 2, maxBounds - minBounds);
    }
}
