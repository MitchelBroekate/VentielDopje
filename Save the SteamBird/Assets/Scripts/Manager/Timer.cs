using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    #region TimerVars
    [Header("TimeVars")]
    [SerializeField] float timerTime = 600;
    [SerializeField] TMP_Text timeM;
    [SerializeField] TMP_Text timeS;
    public bool timeIsRunning = true;
    #endregion

    #region LoseVars
    [Header(header: "LoseVars")]
    bool activateLose = true;
    public GameObject loseCanvas; 
    #endregion

    #region PlayerVars
    [Header("PlayerVars")]
    [SerializeField] PlayerControls playerControls;
    [SerializeField] Transform player;
    [SerializeField] GameObject playerCanvas;
    #endregion

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
                    timeIsRunning = false;
                    Cursor.lockState = CursorLockMode.None;
                    playerControls.winMovement = true;
                    player.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    playerCanvas.SetActive(false);
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

        timeM.text = string.Format("{00:00}", minutes);
        timeS.text = string.Format("{00:00}", seconds);
    }
}
