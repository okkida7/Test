using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeboatController : MonoBehaviour
{
    private LeverController lever;
    private Animator anim;
    public GameObject pressEPanel;
    private bool isLowered = false;
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
        if(isLowered)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                pressEPanel.SetActive(false);
                SceneManager.LoadScene(2);
            }
        }
    }


    // If the player is in the trigger zone and the lifeboat is lowered, show the press E panel and load the next scene
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(ShowPanel());
        }
    }

    IEnumerator ShowPanel()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Lower"))
        {
            yield return new WaitForSeconds(7f);
            isLowered = true;
            pressEPanel.SetActive(true);
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
