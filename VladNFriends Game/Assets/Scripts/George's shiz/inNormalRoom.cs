using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inNormalRoom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Level1.inMirrorRoom = false;
            Level1.inNormalRoom = true;
        }
    }
}
