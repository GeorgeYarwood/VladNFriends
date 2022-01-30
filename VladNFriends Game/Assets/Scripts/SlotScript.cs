using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotScript : MonoBehaviour, IDropHandler
{
    public int id;
    public Canvas myCanvas;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("itemDropped");

        if (eventData.pointerDrag != null)
        {
            if (eventData.pointerDrag.GetComponent<DragNDrop>().id == id)
            {
                Debug.Log("correct");
                myCanvas.GetComponent<PuzzleDone>().nr++;
            }
            else
            {
                Debug.Log("false");
            }
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = this.GetComponent<RectTransform>().anchoredPosition;
        }
    }
}
