using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    //Where items will go when picked up
    public Transform pickUpPos;

    //Show when hovering over item we can pickup
    public GameObject pickUpTxt;

    //Gameobject we're currently holding
    GameObject currHeldObj;

    bool holdingItem = false;
    
    private Outline latestOutline = null;
    public List<WeaponWheelController> controllers;
    public InventoryController invController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {                
        //Cast ray from camera
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out hit, 10f))
        {
            //If the item can be picked up
            if (hit.collider.tag == "pickup")
            {
                if (latestOutline != null)
                {
                    latestOutline.enabled = false;
                    latestOutline = null;
                }
                
                if (!holdingItem) 
                {
                    //Show UI
                    pickUpTxt.SetActive(true);
                }
                
                if (Mouse.current.leftButton.wasPressedThisFrame)
                {
                    currHeldObj = hit.collider.gameObject;
                    holdingItem = false;

                    //Move and parent
                    currHeldObj.transform.position = pickUpPos.transform.position;
                    currHeldObj.GetComponent<Rigidbody>().isKinematic = true;
                    currHeldObj.transform.parent = pickUpPos;
                    holdingItem = true;
                    //Show UI
                    pickUpTxt.SetActive(false);
                }

            }
            
            else if (hit.collider.tag == "InvPickup")
            {
                latestOutline = hit.collider.gameObject.GetComponent<Outline>();
                latestOutline.enabled = true;
                if (Mouse.current.leftButton.wasPressedThisFrame)
                {
                    int IDToEnable = hit.collider.gameObject.GetComponent<Pickupable>().ID;
                    Destroy(hit.collider.gameObject);
                    StartCoroutine(PickedUp(IDToEnable));
                }

            }
            
            else 
            {
                if (latestOutline != null)
                {
                    latestOutline.enabled = false;
                    latestOutline = null;
                }
                pickUpTxt.SetActive(false);
            }
            if(Mouse.current.leftButton.wasReleasedThisFrame && holdingItem)
            {
                //Release
                currHeldObj.GetComponent<Rigidbody>().isKinematic = false;
                currHeldObj.transform.parent = null;
                holdingItem = false;
            }

            
        }

        else
        {
            if (latestOutline != null)
            {
                latestOutline.enabled = false;
                latestOutline = null;
            }
        }
           
    }

    IEnumerator PickedUp(int pickedUp)
    {
        invController.weaponWheelSelected = true;
        controllers[pickedUp].playerHasIt = true;
        yield return new WaitForSeconds(1.0f);
        invController.weaponWheelSelected = false;
    }
}
