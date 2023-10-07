using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

// This class is used to store the dialogue for the NPC
public class Dialogue 
{
    [TextArea(3, 10)]
    public string[] sentences;
}
