using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public Animator anim;
    public bool weaponWheelSelected = false;
    public Image selectedItem;
    public Sprite noImage;
    public static int weaponId;
    private PlayerController character;

    private void Start()
    {
        character = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            weaponWheelSelected = true;
        }
        else if(Input.GetKeyUp(KeyCode.Tab))
        {
            weaponWheelSelected = false;
        }

        if (weaponWheelSelected == true)
        {
            character.enabled = false;
            anim.SetBool("OpenWeaponWheel", true);

            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            character.enabled = true;
            anim.SetBool("OpenWeaponWheel", false);

            Cursor.lockState = CursorLockMode.Locked;
        }

        switch (weaponId)
        {
            case 0:
                break;

            case 1:
                Debug.Log("Red");
                break;

            case 2:
                Debug.Log("Green");
                break;

            case 3:
                Debug.Log("Blue");
                break;

            case 4:
                Debug.Log("Yellow");
                break;
        }
    }
}
