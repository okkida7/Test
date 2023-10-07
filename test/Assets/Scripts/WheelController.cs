using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WheelController : MonoBehaviour
{
    public GameObject wheelPanel;
    public TextMeshProUGUI wheelText;
    private bool isClose = false;

    // If the player is in the trigger zone, show the wheel panel
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            isClose = true;
            wheelPanel.SetActive(true);
            wheelText.text = "Are you sure you want to turn the wheel? (Y/N)";
        }
    }

    // If the player leaves the trigger zone, hide the wheel panel
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            isClose = false;
            wheelPanel.SetActive(false);
            wheelText.text = "";
        }
    }
    void Update()
    {
        if(isClose)
        {
            // If the player is in the trigger zone and presses Y, set the text and start the GameOver coroutine
            if(Input.GetKeyDown(KeyCode.Y))
            {
                wheelText.text = "You have angered the Captain.";
                StartCoroutine(GameOver());
            }
            // If the player is in the trigger zone and presses N, hide the wheel panel and set the text
            else if(Input.GetKeyDown(KeyCode.N))
            {
                wheelPanel.SetActive(false);
                wheelText.text = "";
            }
        }
    }

    // Load the Game Over scene after 3 seconds
    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(1);
    }
}
