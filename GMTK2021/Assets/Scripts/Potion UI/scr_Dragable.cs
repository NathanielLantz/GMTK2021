using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
[RequireComponent(typeof(RectTransform))]
public class scr_Dragable : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    //[SerializeField]
    //DragEffect dragEffect;

    Canvas canvas;
    CanvasGroup canvasGroup;
    RectTransform rectTransform;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();

        if(canvasGroup == null)
        {
            Debug.LogError("No canvas group");
        }
        if(rectTransform == null)
        {
            Debug.LogError("No rect transform");
        }
    }

    public void SetCanvas(Canvas canvas)
    {
        this.canvas = canvas;
    }

    [ContextMenu("Make Draggable")]
    public void MakeDraggable()
    {
        SetDragable(true);
    }

    [ContextMenu("Make Not Draggable")]
    public void MakeNotDraggable()
    {
        SetDragable(false);
    }

    public void SetDragable(bool draggable)
    {
        if(draggable)
        {
            canvasGroup.blocksRaycasts = true;
            canvasGroup.interactable = true;
        }
        else
        {
            canvasGroup.blocksRaycasts = false;
            canvasGroup.interactable = false;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        rectTransform.anchoredPosition = eventData.position / canvas.scaleFactor; //move the mouse the amount the drag was moved
        //dragEffect.Apply();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor; //move the mouse the amount the drag was moved
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        //dragEffect.Unapply();
    }

}
