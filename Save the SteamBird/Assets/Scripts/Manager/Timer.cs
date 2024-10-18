using UnityEngine;
using TMPro;
using System.Collections;

public class Timer : MonoBehaviour
{

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

    #region TimerText
    [Header("TimerText")]
    public TextMeshProUGUI minuteTens;
    public TextMeshProUGUI minuteOnes;
    public TextMeshProUGUI secondTens;
    public TextMeshProUGUI secondOnes;
    #endregion
    
    #region TimeChecks
    [Header("TimeChecks")]
    public float timeRemaining = 600;
    public bool timerIsRunning = false;
    #endregion

    void Start()
    {
        StartCoroutine(StartTimer());
    }

    /// <summary>
    /// This function keeps time running for the timer and activates the lose screen if the timer hits 0
    /// </summary>
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                UpdateTimerDisplay(timeRemaining);
            }
        }
        else if(activateLose && timeRemaining <= 0)
        {
            timeRemaining = 0;
            UpdateTimerDisplay(timeRemaining);

            loseCanvas.SetActive(true);

            timerIsRunning = false;

            Cursor.lockState = CursorLockMode.None;

            playerControls.winMovement = true;

            player.GetComponent<Rigidbody>().velocity = Vector3.zero;

            playerCanvas.SetActive(false);
            
            activateLose = false;
        }
    }

    /// <summary>
    /// This function formats and displays the time
    /// </summary>
    /// <param name="timeToDisplay"></param>
    void UpdateTimerDisplay(float timeToDisplay)
    {

        int minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);

        int minuteTensValue = minutes / 10;
        int minuteOnesValue = minutes % 10;
        int secondTensValue = seconds / 10;
        int secondOnesValue = seconds % 10;

        minuteTens.text = minuteTensValue.ToString();
        minuteOnes.text = minuteOnesValue.ToString();

        secondTens.text = secondTensValue.ToString();
        secondOnes.text = secondOnesValue.ToString();
    }

    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(38);
        timerIsRunning = true;
    }
}
