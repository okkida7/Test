using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeboatController : MonoBehaviour
{
    private LeverController lever;
    private Animator anim;
    public GameObject pressEPanel;
    void Start()
    {
        lever = GameObject.FindWithTag("Lever").GetComponent<LeverController>();
        anim = GetComponent<Animator>();
    }

    // If the lever is pulled, lower the lifeboat
    void Update()
    {
        if(lever == null)
        {
            lever = GameObject.FindWithTag("Lever").GetComponent<LeverController>();
        }
        if(lever.isPulled == true)
        {
            anim.SetTrigger("lower");
        }
    }


    // If the player is in the trigger zone and the lifeboat is lowered, show the press E panel and load the next scene
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(anim.GetCurrentAnimatorStateInfo(0).IsName("Lower"))
            {
                pressEPanel.SetActive(true);
                if(Input.GetKeyDown(KeyCode.E))
                {
                    pressEPanel.SetActive(false);
                    SceneManager.LoadScene(2);
                }
            }
        }
    }

    // If the player is in the trigger zone, hide the press E panel
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            pressEPanel.SetActive(false);
        }
    }
}
