using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLockedDoor : MonoBehaviour
{
    public RoomKeyController roomKey;
    private MeshRenderer meshRenderer;
    private Collider boxCollider;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        boxCollider = GetComponent<BoxCollider>();
    }

    //  If the player is in the trigger zone, hide the door
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && roomKey.isPickedUp)
        {
            meshRenderer.enabled = false;
            boxCollider.enabled = false;
        }
    }
}
