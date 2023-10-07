using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRestartController : MonoBehaviour
{
    // This method is called when the Restart button is clicked
    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
