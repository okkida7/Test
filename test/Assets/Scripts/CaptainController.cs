using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CaptainController : MonoBehaviour
{
    public GameObject captainPanel;
    private GunController gun;
    void Start()
    {
        // Find tagged object with GunController script
        gun = GameObject.FindWithTag("Gun").GetComponent<GunController>();
    }
    void Update()
    {
        // If gun is null, try to find tagged object with GunController script in Update
        if (gun == null)
        {
            Debug.Log("Gun is null");
            gun = GameObject.FindWithTag("Gun").GetComponent<GunController>();
        }
    }

    // If player enters trigger and has gun, show captainPanel and start EndGame coroutine
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && gun.hasGun == true)
        {
            captainPanel.SetActive(true);
            StartCoroutine(EndGame());
        }
    }

    // If player exits trigger, hide captainPanel
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            captainPanel.SetActive(false);
        }
    }

    // Load end scene after 3 seconds
    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(2);
    }
}
