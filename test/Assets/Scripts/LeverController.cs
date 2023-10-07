using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeverController : MonoBehaviour
{
    public GameObject leverPanel;
    public TextMeshProUGUI leverText;
    public bool isPulled = false;
    private MeshRenderer meshRenderer;
    private LifeboatKeyController key;
    private Animator anim;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        key = GameObject.FindWithTag("LifeboatKey").GetComponent<LifeboatKeyController>();
        anim = GetComponent<Animator>();
    }

    // If the player is in the trigger zone, change the color of the lever
    void OnTriggerEnter(Collider other)
    {
        if(key == null)
        {
            key = GameObject.FindWithTag("LifeboatKey").GetComponent<LifeboatKeyController>();
        }
        // If the player is in the trigger zone and has the key, change the color of the lever and pull it
        if(other.tag == "Player" && key.isPickedUp == true)
        {
            meshRenderer.material.color = Color.green;
            anim.SetTrigger("pull");
            isPulled = true;
        }

        // If the player is in the trigger zone and does not have the key, change the color of the lever and show the lever panel
        else if(other.tag == "Player" && key.isPickedUp == false)
        {
            meshRenderer.material.color = Color.red;
            leverPanel.SetActive(true);
            leverText.text = "The boat is locked. Unable to pull lever.";
        }
    }


    // If the player is in the trigger zone, hide the lever panel
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            leverPanel.SetActive(false);
        }
    }
}
