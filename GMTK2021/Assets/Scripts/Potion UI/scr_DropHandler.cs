using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

[System.Serializable]
class GameObjectDroppedEvent : UnityEvent<GameObject> { }

[RequireComponent(typeof(RectTransform))]
public class scr_DropHandler : MonoBehaviour, IDropHandler
{
    ISlot slot;

    RectTransform rectTransform;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        slot = GetComponent<ISlot>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        GameObject draggedObject = eventData.pointerDrag;
        if(draggedObject == null) { return; }

        scr_Dragable dragable = draggedObject.GetComponent<scr_Dragable>();
        if (slot != null)
        {
            if (slot.IsOccupied())
            {
                dragable.DropNotAllowed();
                return;
            }

            slot.SetObject(draggedObject);
        }


        RectTransform draggedRectTransform = draggedObject.GetComponent<RectTransform>();
        draggedRectTransform.anchoredPosition = rectTransform.anchoredPosition;
        dragable.DisableDragging();
    }
}
