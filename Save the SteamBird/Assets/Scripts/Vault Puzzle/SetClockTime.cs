using UnityEngine;
using TMPro;

public class SetClockTime : MonoBehaviour
{
    public TMP_Text timeText;
    int timeToDisplay;

    public string timeCode;

    void Start()
    {
        SetTime();   
    }

    void SetTime()
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }
        else if(timeToDisplay > 0)
        {
            timeToDisplay += 1;
        }

        float minutes = Random.Range(1, 24);
        float seconds = Random.Range(1, 59);

        timeText.text = string.Format("{00:00}:{01:00}", minutes, seconds);

        timeCode = timeText.text;
    }
}
