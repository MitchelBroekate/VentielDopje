using System.Collections.Generic;
using UnityEngine;

public class PipePuzzleManager : MonoBehaviour
{
    public List<Transform> transforms = new List<Transform>();

    void Start()
    {
        List<int> uniqueNumbers = new List<int> { 0, 1, 2, 3, 4 };

        ShuffleList(uniqueNumbers);

        for (int i = 0; i < transforms.Count; i++)
        {
            Debug.Log($"Transform {transforms[i].name} gets random number {uniqueNumbers[i]}");
        }
    }

    // Helper method to shuffle the list
    void ShuffleList(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randomIndex = Random.Range(i, list.Count);
            int temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    public void RandomPipeSelector()
    {

    }

    public void PipePuzzleReset()
    {


        RandomPipeSelector();
    }
}
