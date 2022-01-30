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

    Rigidbody playerRb;

    GameObject chair;

    static public bool teleporting;

    Animator playAnim;

    public WeaponWheelController ww;

    // Start is called before the first frame update
    void Start()
    {
        //Find our player and its character controller
        currPlayer = GameObject.FindGameObjectWithTag("Player");
        charController = currPlayer.GetComponent<PlayerController>();
        charController.enabled = false;
        playAnim = currPlayer.GetComponentInChildren<Animator>();
        chair = GameObject.FindGameObjectWithTag("chair");
        playerRb = currPlayer.GetComponent<Rigidbody>();
        StartCoroutine(waitForAnim());
    }

    IEnumerator waitForAnim() 
    {
        yield return new WaitForSeconds(10);
        charController.enabled = true;
        PlayerController.mouseMoveEnabled = true;
        PlayerController.keyMoveEnabled = false;

    }


   

    

    // Update is called once per frame
    void Update()
    {
        
        if (inNormalRoom && !isFree) 
        {
            PlayerController.keyMoveEnabled = false;

            //If player has the knife
            if (ww.playerHasIt)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    RaycastHit hit;
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                    if (Physics.Raycast(ray,out hit))
                    {
                        if (hit.transform.name == "chains") 
                        {
                            hit.transform.gameObject.SetActive(false);
                            isFree = true;
                        }
                    }
                }

            }

        }
        else if (inMirrorRoom && !isFree)
        {
            PlayerController.keyMoveEnabled = true;

        }
        if (isFree) 
        {
            PlayerController.mouseMoveEnabled = true;
            PlayerController.keyMoveEnabled = true;

        }
    }
   

}
