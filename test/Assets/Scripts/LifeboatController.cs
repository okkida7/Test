using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeboatController : MonoBehaviour
{
    private LifeboatKeyController lifeboatKey;
    private Animator anim;
    void Start()
    {
        lifeboatKey = GameObject.FindWithTag("LifeboatKey").GetComponent<LifeboatKeyController>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if(lifeboatKey == null)
        {
            Debug.Log("LifeboatKey not found!");
            return;
        }
        if(lifeboatKey.isPickedUp == true)
        {
            anim.SetTrigger("lower");
        }
    }
}
