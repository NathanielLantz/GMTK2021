using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
[RequireComponent(typeof(RectTransform))]
public class scr_Dragable : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField]
    scr_PotionManager potionManager;
    //[SerializeField]
    //DragEffect dragEffect;

    Canvas canvas;
    CanvasGroup canvasGroup;
    RectTransform rectTransform;
    bool isDraggable;
    scr_IngredientUI ingredientUI;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
        ingredientUI = GetComponent<scr_IngredientUI>();

        if(canvasGroup == null)
        {
            Debug.LogError("No canvas group");
        }
        if(rectTransform == null)
        {
            Debug.LogError("No rect transform");
        }
        if(ingredientUI == null)
        {
            Debug.LogError("No ingredient ui");
        }
    }

    private void Start()
    {
    }

    public void SetCanvas(Canvas canvas)
    {
        this.canvas = canvas;
    }

    public void EnableDragging()
    {
        SetDragable(true);
        isDraggable = true;
    }

    public void DisableDragging()
    {
        SetDragable(false);
        isDraggable = false;

    }
    private void SetDragable(bool draggable)
    {

        if (draggable)
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
        ingredientUI.IsSetInSlot = false;
        rectTransform.anchoredPosition = eventData.position / canvas.scaleFactor; //move the mouse the amount the drag was moved
        //dragEffect.StartDragging();
        scr_AudioManager.PlaySoundEffect(scr_PotionUI.Instance.IngredientPickedUpSFX);
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor; //move the mouse the amount the drag was moved
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(isDraggable)
        {
            SetDragable(true);
        }
        scr_AudioManager.PlaySoundEffect(scr_PotionUI.Instance.IngredientDroppedSFX);
         
        //dragEffect.StopDragging();
    }

    public void DropNotAllowed()
    {
        canvasGroup.alpha = 0.5f;
        Debug.Log("Attempted to drag an ingredient into a full slot");
        //dragEFfect.DropNotAllowed();
    }

}
