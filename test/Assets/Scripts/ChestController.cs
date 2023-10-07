using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChestController : MonoBehaviour
{
    public GameObject chestPanel;
    public UIController ui;

    // If the player is in the trigger zone and the password is not correct, show the chest panel
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !ui.isCorrect)
        {
            chestPanel.SetActive(true);
        }
    }

    // If the player is in the trigger zone and the password is correct/incorrect, hide the chest panel
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            chestPanel.SetActive(false);
        }
    }
}
