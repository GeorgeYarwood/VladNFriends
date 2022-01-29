using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyVal : MonoBehaviour
{
    [SerializeField] private int value = 0;
    [SerializeField] private Keypad pad;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Keypad"))
        {
            if (pad.inputCode.text == "XXXX")
            {
                pad.inputCode.text = value.ToString();
            }
            else
            {
                pad.inputCode.text += value.ToString();    
            }
        }
    }
}
