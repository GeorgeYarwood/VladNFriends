using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyVal : MonoBehaviour
{
    [SerializeField] private int value = 0;
    [SerializeField] private Keypad pad;
    private Vector3 pos;

    void Start()
    {
        pos = transform.position;
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Keypad"))
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
        
        else if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ResetPos());
        }
    }

    IEnumerator ResetPos()
    {
        yield return new WaitForSeconds(2.0f);
        transform.position = pos;
    }
}
