using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
public class scr_DropHandler : MonoBehaviour, IDropHandler
{
    RectTransform rectTransform;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        GameObject draggedObject = eventData.pointerDrag;
        RectTransform draggedRectTransform = draggedObject.GetComponent<RectTransform>();
        draggedRectTransform.anchoredPosition = rectTransform.anchoredPosition;
        Debug.Log("OnDrop");
    }
}
