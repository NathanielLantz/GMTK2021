using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_DragCanvasManager : MonoBehaviour
{
    scr_IngredientUI[] inventoryUIs;
    private void Start()
    {
        Canvas canvas = GetComponent<Canvas>();

        inventoryUIs = scr_PotionUI.Instance.IngredientUIs;

        foreach(scr_IngredientUI inventoryUI in inventoryUIs)
        {

            bool activeState = inventoryUI.gameObject.activeSelf;
            inventoryUI.gameObject.SetActive(true);
            scr_Dragable dragable = inventoryUI.GetComponent<scr_Dragable>();
            dragable.SetCanvas(canvas);
            inventoryUI.gameObject.SetActive(activeState);
            Debug.Log("setting canvas on " + inventoryUI.name);
        }
    }
}
