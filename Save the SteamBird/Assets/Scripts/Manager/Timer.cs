using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    float timerTime = 600;
    [SerializeField] TMP_Text time;
    public bool timeIsRunning = true;
    bool activateLose = true;
    public GameObject loseCanvas; 

    /// <summary>
    /// This function keeps time running for the timer
    /// </summary>
    void Update()
    {
        if(timeIsRunning)
        {
            if(timerTime > 0)
            {
                timerTime -= Time.deltaTime;
            }
            else
            {
                if(activateLose)
                {
                    loseCanvas.SetActive(true);
                    activateLose = false;
                }
            }

            DisplayTime(timerTime);
        }
    }

    /// <summary>
    /// This function formats and displays the time
    /// </summary>
    /// <param name="timeToDisplay"></param>
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
