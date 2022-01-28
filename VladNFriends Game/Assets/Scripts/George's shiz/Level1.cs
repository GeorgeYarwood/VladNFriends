using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    //If player has free'd themselves from the chair
    bool isFree;

    CharacterController charController;
    GameObject currPlayer;

    // Start is called before the first frame update
    void Start()
    {
        //Find our player and its character controller
        currPlayer = GameObject.FindGameObjectWithTag("Player");
        charController = currPlayer.GetComponentInChildren<CharacterController>();
        charController.gameObject.SetActive(false);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
