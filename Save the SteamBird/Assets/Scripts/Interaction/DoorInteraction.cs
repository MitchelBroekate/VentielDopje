using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class DoorInteraction : MonoBehaviour
{
    public Transform doorRotate;
    bool coroutineActive;

    public PuzzleManager puzzleManager;
    public UIFade uIFade;
    public Timer timer;
    public PlayerControls playerControls;

    public GameObject player;
    public GameObject playerCanvas;

    public AudioSource audioSource;
    public AudioClip doorSqueek;
    public AudioSource winSource;
    public AudioClip winClip;

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
            winSource.clip = winClip;
            winSource.Play();

            uIFade.canFade = true;
            timer.timerIsRunning = false;
            Cursor.lockState = CursorLockMode.None;
            playerControls.winMovement = true;
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            playerCanvas.SetActive(false);
        }

    }

    IEnumerator DoorWiggle()
    {
        audioSource.clip = doorSqueek;
        audioSource.Play();

        coroutineActive = true;
        doorRotate.Rotate(0, 0, 100);
        yield return new WaitForSeconds(0.5f);

        coroutineActive = false;
        coroutineActive = true;
        doorRotate.Rotate(0, 0, -200);
        yield return new WaitForSeconds(0.5f);

        coroutineActive = false;
        StopAllCoroutines();
    }
}
