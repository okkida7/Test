using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{
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
    void OnTriggerEnter(Collider other)
    {
        if(key == null)
        {
            Debug.Log("LifeboatKey not found!");
            return;
        }
        if(other.tag == "Player" && key.isPickedUp == true)
        {
            meshRenderer.material.color = Color.green;
            anim.SetTrigger("pull");
            isPulled = true;
        }
        else
        {
            meshRenderer.material.color = Color.red;
        }
    }
}
