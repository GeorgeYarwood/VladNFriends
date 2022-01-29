using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public Animator anim;
    private bool weaponWheelSelected = false;
    public Image selectedItem;
    public Sprite noImage;
    public static int weaponId;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            weaponWheelSelected = !weaponWheelSelected;
        }

        if (weaponWheelSelected == true)
        {
            anim.SetBool("OpenWeaponWheel", true);
        }
        else
        {
            anim.SetBool("OpenWeaponWheel", false);
        }

        switch (weaponId)
        {
            case 0:
                selectedItem.sprite = noImage;
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
