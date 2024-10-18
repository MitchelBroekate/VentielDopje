using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class DoorInteraction : MonoBehaviour
{
    public Transform doorRotate;
    bool coroutineActive;

    public PuzzleManager puzzleManager;
    public Timer timer;
    public PlayerControls playerControls;

    public GameObject player;
    public GameObject playerCanvas;
    public GameObject winCanvas;
    void Update()
    {
        if (coroutineActive) 
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, doorRotate.rotation, 0.2f * Time.deltaTime);
        }
    }

    public void DoorInteract()
    {
        if(!puzzleManager.gameWon)
        {
            if(!coroutineActive)
            {
                StartCoroutine(DoorWiggle());
            }
        }
        else
        {
            timer.timerIsRunning = false;
            Cursor.lockState = CursorLockMode.None;
            playerControls.winMovement = true;
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            playerCanvas.SetActive(false);
            winCanvas.SetActive(true);
        }

    }

    IEnumerator DoorWiggle()
    {
        coroutineActive = true;
        doorRotate.Rotate(0, 0, 20);
        yield return new WaitForSeconds(0.25f);

        doorRotate.Rotate(0, 0, -30);
        yield return new WaitForSeconds(0.25f);

        doorRotate.Rotate(0, 0, 20);
        yield return new WaitForSeconds(0.25f);

        doorRotate.Rotate(0, 0, -30);
        yield return new WaitForSeconds(0.25f);

        doorRotate.Rotate(0, 0, 20);
        yield return new WaitForSeconds(0.25f);

        coroutineActive = false;
        StopAllCoroutines();
    }
}
