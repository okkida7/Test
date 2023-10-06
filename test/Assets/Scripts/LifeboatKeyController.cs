using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeboatKeyController : MonoBehaviour
{
    public bool isPickedUp = false;
    private MeshRenderer meshRenderer;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPickedUp = true;
            meshRenderer.enabled = false;
        }
    }
}
