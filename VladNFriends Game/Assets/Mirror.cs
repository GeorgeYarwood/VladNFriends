using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    public Transform endPos;
    public Transform startPos;

    public GameObject mainCam;
    public GameObject startCam;
    public GameObject endCam;

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {
        Vector3 rotation = new Vector3(mainCam.transform.rotation.eulerAngles.x, mainCam.transform.rotation.eulerAngles.y, mainCam.transform.rotation.eulerAngles.z);
        startCam.transform.rotation = Quaternion.Euler(rotation);
        
        rotation = new Vector3(mainCam.transform.rotation.eulerAngles.x, mainCam.transform.rotation.eulerAngles.y, mainCam.transform.rotation.eulerAngles.z);
        endCam.transform.rotation = Quaternion.Euler(rotation);
    }
}
