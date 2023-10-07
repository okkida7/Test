using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public bool hasGun = false;
    private MeshRenderer meshRenderer; 

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // If the player is in the trigger zone, hide the gun and set hasGun to true
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            meshRenderer.enabled = false;
            hasGun = true;
        }
    }
}
