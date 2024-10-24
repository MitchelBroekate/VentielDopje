using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevTools : MonoBehaviour
{
    public Transform birdpart1, birdpart2, birdpart3, birdpart4;

    public Timer timer;
    public Interaction interaction;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            birdpart1.transform.position = transform.position;
            birdpart2.transform.position = transform.position;
            birdpart3.transform.position = transform.position;
            birdpart4.transform.position = transform.position;
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            timer.timerIsRunning = true;
            timer.timeRemaining = 1;
        }

        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            interaction.IntroCheck = true;
        }
    }
}
