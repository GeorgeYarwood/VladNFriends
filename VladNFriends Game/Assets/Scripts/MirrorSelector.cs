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
                if (Keyboard.current.eKey.wasPressedThisFrame)
                {
                    Debug.Log("TPd to Dark");
                    GetComponent<CharacterController>().enabled = false;
                    transform.position = _hit.transform.parent.gameObject.GetComponent<Mirror>().endPos.position;
                    
                    GetComponent<CharacterController>().enabled = true;
                }

                latestOutline = _hit.transform.GetComponent<Outline>();
                latestOutline.enabled = true;
            }
            
            else if (_hit.collider.CompareTag("MirrorEnd"))
            {
                if (Keyboard.current.eKey.wasPressedThisFrame)
                {
                    Debug.Log("TPd to light");
                    GetComponent<CharacterController>().enabled = false;
                    transform.position = _hit.transform.parent.gameObject.GetComponent<Mirror>().startPos.position;
                    
                    GetComponent<CharacterController>().enabled = true;
                    
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
    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(_ray.origin, _ray.direction);
    }
}
