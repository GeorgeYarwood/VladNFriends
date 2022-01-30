using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleDone : MonoBehaviour
{
    public int nr=0;

    private void Update()
    {
        if(nr==4)
        {
            //win minigame

            Debug.Log("PuzzleDone");
        }
    }
}
