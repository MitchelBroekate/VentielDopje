using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class PipeRotateManager : MonoBehaviour
{
    public PipeRotateIneractable pipe1, pipe2, pipe3, pipe4, pipe5, pipe6, pipe7, pipe8;

    [SerializeField] bool pipe1Correct,pipe2Correct,pipe3Correct,pipe4Correct,pipe5Correct,pipe6Correct,pipe7Correct,pipe8Correct;

    public PuzzleManager puzzleManager;

    public void PipeWinCheck()
    {

        if(pipe1.rotateValue == 2 || pipe1.rotateValue == 3)
        {
            pipe1Correct = true;
        }
        else
        {
            pipe1Correct = false;
        }

        if(pipe2.rotateValue == 1)
        {
            pipe2Correct = true;
        }
        else
        {
            pipe2Correct = false;
        }

        if(pipe3.rotateValue == 1 || pipe3.rotateValue == 3)
        {
            pipe3Correct = true;
        }
        else
        {
            pipe3Correct = false;
        }

        if(pipe4.rotateValue == 3 || pipe4.rotateValue == 2)
        {
            pipe4Correct = true;
        }
        else
        {
            pipe4Correct = false;
        }

        if(pipe5.rotateValue == 2)
        {
            pipe5Correct = true;
        }
        else
        {
            pipe5Correct = false;
        }

        if(pipe6.rotateValue == 1 || pipe6.rotateValue == 3)
        {
            pipe6Correct = true;
        }
        else
        {
            pipe6Correct = false;
        }

        if(pipe7.rotateValue == 3)
        {
            pipe7Correct = true;
        }
        else
        {
            pipe7Correct = false;
        }

        if(pipe8.rotateValue == 2 || pipe8.rotateValue == 3)
        {
            pipe8Correct = true;
        }
        else
        {
            pipe8Correct = false;
        }

        if(pipe1Correct && pipe2Correct && pipe3Correct && pipe4Correct && pipe5Correct && pipe6Correct && pipe7Correct && pipe8Correct)
        {
            puzzleManager.PipeRotateCompletion();
        }
    }
}
