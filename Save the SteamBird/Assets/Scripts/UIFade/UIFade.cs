using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFade : MonoBehaviour
{
    public CanvasGroup fadeCanvas;
    public bool canFade;
    public GameObject winCanvas;
    public GameObject fadeScreen;

    void Start()
    {
        fadeCanvas.alpha = 0f;
    }

    void Update()
    {
        if(canFade)
        {

            if(fadeCanvas.alpha < 1)
            {
                fadeScreen.SetActive(true);
                fadeCanvas.alpha += 0.3f * Time.deltaTime;
            }
            else if(fadeCanvas.alpha >= 1)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                winCanvas.SetActive(true);
                fadeCanvas.gameObject.SetActive(false);
            }
        }
    }
}
