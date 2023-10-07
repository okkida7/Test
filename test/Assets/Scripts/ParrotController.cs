using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ParrotController : MonoBehaviour
{
    public GameObject parrotPanel;

    // If the player is in the trigger zone, show the parrot panel
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            parrotPanel.SetActive(true);
        }
    }

    // If the player leaves the trigger zone, hide the parrot panel
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            parrotPanel.SetActive(false);
        }
    }
}
