using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomKeyController : MonoBehaviour
{
    public bool isPickedUp = false;
    private MeshRenderer meshRenderer;
    public UIController ui;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // If the player is in the trigger zone, hide the key and set isPickedUp to true
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && ui.isCorrect)
        {
            isPickedUp = true;
            meshRenderer.enabled = false;
        }
    }
}
