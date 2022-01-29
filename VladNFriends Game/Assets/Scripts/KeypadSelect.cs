using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeypadSelect : MonoBehaviour
{
    private Outline latestOutline = null;
    
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out hit, 10f))
        {
            if (hit.collider.tag == "Keypad")
            {
                latestOutline = hit.collider.gameObject.GetComponent<Keypad>().outline;
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

        else
        {
            if (latestOutline != null)
            {
                latestOutline.enabled = false;
                latestOutline = null;
            }
        }
    }
}
