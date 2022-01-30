using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    //If player has free'd themselves from the chair
    bool isFree;

    static public bool inNormalRoom;
    static public bool inMirrorRoom;

    PlayerController charController;
    GameObject currPlayer;

    GameObject chair;

    Animator playAnim;

    // Start is called before the first frame update
    void Start()
    {
        //Find our player and its character controller
        currPlayer = GameObject.FindGameObjectWithTag("Player");
        charController = currPlayer.GetComponent<PlayerController>();
        charController.enabled = false;
        playAnim = currPlayer.GetComponentInChildren<Animator>();
        chair = GameObject.FindGameObjectWithTag("chair");
        StartCoroutine(waitForAnim());
    }

    IEnumerator waitForAnim() 
    {
        yield return new WaitForSeconds(10);
        charController.enabled = true;
        PlayerController.mouseMoveEnabled = true;
        PlayerController.keyMoveEnabled = false;

    }


    IEnumerator waitForReset() 
    {
        yield return new WaitForSeconds(0.1f);

    }

    // Update is called once per frame
    void Update()
    {
        if (inMirrorRoom && !isFree) 
        {
            PlayerController.keyMoveEnabled = true;

        }
        else if(inNormalRoom && !isFree) 
        {
            PlayerController.keyMoveEnabled = false;
            currPlayer.transform.position = chair.transform.position;

        }

    }
   

}
