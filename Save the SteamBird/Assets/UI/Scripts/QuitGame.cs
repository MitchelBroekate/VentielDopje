using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour

{
    public void quitTheGame()
    {
        Application.Quit();
        Debug.Log("Closing game");

    }

}
   