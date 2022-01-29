using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class MirrorSelector : MonoBehaviour
{
    [SerializeField] private float interactDist = 2.0f;
    
    private Camera mainCam;
    private Ray _ray;
    private RaycastHit _hit;

    private Outline latestOutline = null;
    
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        _ray = mainCam.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(_ray, out _hit, interactDist))
        {
            if (_hit.collider.CompareTag("MirrorStart"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("going to end");
                    GetComponent<PlayerController>().enabled = false;
                    transform.position = _hit.transform.parent.gameObject.GetComponent<Mirror>().endPos.position;
                    //transform.rotation = _hit.transform.parent.gameObject.GetComponent<Mirror>().endPos.rotation;
                    transform.Rotate(new Vector3(0,-180,0));
                    GetComponent<PlayerController>().enabled = true;
                }

                latestOutline = _hit.transform.GetComponent<Outline>();
                latestOutline.enabled = true;
            }
            
            else if (_hit.collider.CompareTag("MirrorEnd"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("going to start");
                    GetComponent<PlayerController>().enabled = false;
                    transform.position = _hit.transform.parent.gameObject.GetComponent<Mirror>().startPos.position;
                    //transform.rotation = _hit.transform.parent.gameObject.GetComponent<Mirror>().startPos.rotation;
                    transform.Rotate(new Vector3(0,-180,0));
                    GetComponent<PlayerController>().enabled = true;
                    
                }
                
                latestOutline = _hit.transform.GetComponent<Outline>();
                latestOutline.enabled = true;
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
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MirrorStart"))
        {
            GetComponent<PlayerController>().enabled = false;
            transform.position = other.gameObject.transform.parent.gameObject.GetComponent<Mirror>().endPos.position;
            //transform.rotation = other.gameObject.transform.parent.gameObject.GetComponent<Mirror>().endPos.rotation;
            transform.Rotate(new Vector3(0,-180,0));
            GetComponent<PlayerController>().enabled = true;
        }
        
        else if (other.gameObject.CompareTag("MirrorEnd"))
        {
            GetComponent<PlayerController>().enabled = false;
            transform.position = other.gameObject.transform.parent.gameObject.GetComponent<Mirror>().startPos.position;
            //transform.rotation = other.gameObject.transform.parent.gameObject.GetComponent<Mirror>().startPos.rotation;
            transform.Rotate(new Vector3(0,-180,0));
            GetComponent<PlayerController>().enabled = true;   
        }
    }
    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(_ray.origin, _ray.direction);
    }
}
