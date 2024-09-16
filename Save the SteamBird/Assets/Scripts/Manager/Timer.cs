using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    float timerTime = 600;
    [SerializeField] TMP_Text time;

    void Update()
    {
        if(timerTime > 0)
        {
            timerTime -= Time.deltaTime;
        }
        else
        {
            timerTime = 600;
        }

        DisplayTime(timerTime);
    }

    void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }
        else if(timeToDisplay > 0)
        {
            timeToDisplay += 1;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay/60);
        float seconds = Mathf.FloorToInt(timeToDisplay%60);

        time.text = string.Format("{00:00}:{01:00}", minutes, seconds);
    }
}
