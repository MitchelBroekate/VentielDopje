using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToGame : MonoBehaviour
{

    [System.Obsolete]
    public void ToMainGame()
    {
        Application.LoadLevel(1);
    }

    

}
