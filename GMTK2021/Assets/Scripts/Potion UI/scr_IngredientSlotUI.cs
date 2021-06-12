using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface ISlot
{
    bool IsOccupied();
    void SetObject(GameObject objectHeld);
    void UnsetObject();
}

public class scr_IngredientSlotUI : MonoBehaviour, ISlot
{
    [SerializeField]
    scr_PotionManager potionManager;
    scr_IngredientUI heldIngredientUI;

    private void SetIngredientInSlot(scr_IngredientUI ingredientUI)
    {
        if (ingredientUI == null) { Debug.LogError("Got a null ingredient"); }

        heldIngredientUI = ingredientUI;
        ingredientUI.IsSetInSlot = true;
        potionManager.SelectIngredient(transform.GetSiblingIndex(), ingredientUI.CurrentIngredient);
        Debug.Log("adding " + ingredientUI.CurrentIngredient + " at " + transform.GetSiblingIndex());
        Debug.Log("Set ingredient to " + ingredientUI.CurrentIngredient.Name);
    }

    public void UnsetIngredient()
    {
        if (heldIngredientUI != null)
        {
            heldIngredientUI.gameObject.SetActive(false);
            heldIngredientUI = null;
        }
    }

    public bool IsOccupied()
    {
        return heldIngredientUI != null;
    }

    public void SetObject(GameObject gameObjectToHold)
    {
        scr_IngredientUI ingredientToHoldUI = gameObjectToHold.GetComponent<scr_IngredientUI>();
        if(ingredientToHoldUI == null) { Debug.LogWarning("Expected game object to be an ingredient."); }

        SetIngredientInSlot(ingredientToHoldUI);
    }

    public void UnsetObject()
    {
        UnsetIngredient();
        Debug.Log("removing at " + transform.GetSiblingIndex());
    }
}
