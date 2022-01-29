using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    public Outline outline;
    [SerializeField] private Camera keyCam;
    [SerializeField] private string correctCode;
    public TextMeshProUGUI inputCode;

    void Update()
    {
        if (inputCode.text.Length > 3 && inputCode.text != "XXXX")
        {
            if (inputCode.text == correctCode)
            {
                inputCode.color = Color.green;
            }
            else
            {
                inputCode.color = Color.red;
                StartCoroutine(Reset());
            }
        }
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(1.0f);
        inputCode.color = Color.white;
        inputCode.text = "XXXX";
    }
}
