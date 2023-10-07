using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCaptainDoor : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    //  If the player is in the trigger zone, open the door
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("open");
        }
    }
}
