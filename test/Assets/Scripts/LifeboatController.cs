using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeboatController : MonoBehaviour
{
    private LeverController lever;
    private Animator anim;
    void Start()
    {
        lever = GameObject.FindWithTag("Lever").GetComponent<LeverController>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if(lever == null)
        {
            Debug.Log("Lever not found!");
            return;
        }
        if(lever.isPulled == true)
        {
            anim.SetTrigger("lower");
        }
    }
}
