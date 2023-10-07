using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    // The password is 378
    private string password = "378";
    // This bool is used to check if the password is correct
    public bool isCorrect = false;
    // The input field where the player enters the password
    public TMP_InputField inputField;
    // The text that displays if the password is correct or incorrect
    public TextMeshProUGUI passwordText;
    // The panel that displays the password input field
    public GameObject chestPanel;
    // The panel that displays the chest opening animation
    public GameObject parrotPanel;
    // The panel that displays the parrot dialogue
    public GameObject captainPanel;
    // The text that displays the parrot dialogue
    public TextMeshProUGUI captainText;
    // The text that displays the captain dialogue
    public TextMeshProUGUI parrotText;
    // The queue that stores the parrot dialogue sentences
    private Queue<string> parrotSentences;
    // The queue that stores the captain dialogue sentences
    private Queue<string> captainSentences;
    // The animator for the chest opening animation
    public Animator anim;
    // The dialogue for the parrot
    public Dialogue parrotDialogue;
    // The dialogue for the captain
    public Dialogue captainDialogue;
    // This bool is used to check if the parrot dialogue has started
    private bool isParrotDialogueStarted = false;
    // This bool is used to check if the captain dialogue has started
    private bool isCaptainDialogueStarted = false;
    void Start()
    {
        captainSentences = new Queue<string>();
        parrotSentences = new Queue<string>();

    }

    // If the player clicks the button, check if the password is correct
    public void CheckPassword()
    {
        if(inputField.text == password)
        {
            passwordText.text = "Correct";
            chestPanel.SetActive(false);
            anim.SetTrigger("open");
            isCorrect = true;
        }
        else
        {
            passwordText.text = "Incorrect";
        }
    }

    public void Update()
    {
        // If the parrot panel is active and the captain panel is inactive, start the parrot dialogue
        if(parrotPanel.activeSelf && !captainPanel.activeSelf)
        {
            if(!isParrotDialogueStarted)
            {
                StartParrotDialogue(parrotDialogue);
                isParrotDialogueStarted = true;
            }
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                DisplayParrotNextSentence();
            }
        }
        // If the captain panel is active and the parrot panel is inactive, reset the parrot dialogue
        else if(!parrotPanel.activeSelf)
        {
            isParrotDialogueStarted = false;
            ResetParrotDialogue();  
        }
        // If the captain panel is active and the parrot panel is inactive, start the captain dialogue
        if(captainPanel.activeSelf && !parrotPanel.activeSelf)
        {
            if(!isCaptainDialogueStarted)
            {
                StartCaptainDialogue(captainDialogue);
                isCaptainDialogueStarted = true;
            }
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                DisplayCaptainNextSentence();
            }
        }
        // If the parrot panel is active and the captain panel is inactive, reset the captain dialogue
        else if(!captainPanel.activeSelf)
        {
            isCaptainDialogueStarted = false;
            ResetCaptainDialogue();  
        }
    }

    // Start the parrot dialogue
    public void StartParrotDialogue(Dialogue dialogue)
    {
        parrotSentences.Clear();
        foreach(string sentence in dialogue.sentences)
        {
            parrotSentences.Enqueue(sentence);
        }
        DisplayParrotBeginningSentence();
    }

    // Start the captain dialogue
    public void StartCaptainDialogue(Dialogue dialogue)
    {
        captainSentences.Clear();
        foreach(string sentence in dialogue.sentences)
        {
            captainSentences.Enqueue(sentence);
        }
        DisplayCaptainBeginningSentence();
    }

    // Display the next sentence in the parrot dialogue
    public void DisplayParrotNextSentence()
    {
        if(parrotSentences.Count == 0)
        {
            parrotPanel.SetActive(false);
            return;
        }
        string parrotSentence = parrotSentences.Dequeue();
        parrotText.text = parrotSentence;
    }

    // Display the next sentence in the captain dialogue
    public void DisplayCaptainNextSentence()
    {
        if(captainSentences.Count == 0)
        {
            captainPanel.SetActive(false);
            return;
        }
        string captainSentence = captainSentences.Dequeue();
        captainText.text = captainSentence;
    }

    // Reset the parrot dialogue when the panel is closed
    public void ResetParrotDialogue()
    {
        StartParrotDialogue(parrotDialogue);
    }

    // Reset the captain dialogue when the panel is closed
    public void ResetCaptainDialogue()
    {
        StartCaptainDialogue(captainDialogue);
    }

    // Display the beginning sentence when parrot dialogue starts
    public void DisplayParrotBeginningSentence()
    {
        if(parrotSentences.Count > 0)
        {
            string parrotSentence = parrotSentences.Peek(); // Peek to get the first sentence without removing it
            parrotText.text = parrotSentence;
        }
    }

    // Display the beginning sentence when captain dialogue starts
    public void DisplayCaptainBeginningSentence()
    {
        if(captainSentences.Count > 0)
        {
            string captainSentence = captainSentences.Peek(); // Peek to get the first sentence without removing it
            captainText.text = captainSentence;
        }
    }

}
