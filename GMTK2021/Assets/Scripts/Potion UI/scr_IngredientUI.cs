using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scr_IngredientUI : MonoBehaviour
{
    Image image;
    [SerializeField]
    TextMeshProUGUI label;

    scr_Ingredient currentIngredient;
    public scr_Ingredient CurrentIngredient => currentIngredient;

    scr_Dragable dragable;

    public bool IsSetInSlot;

    private void Awake()
    {
        image = GetComponent<Image>();
        dragable = GetComponent<scr_Dragable>();
        IsSetInSlot = false;
    }
    public void SetIngredient(scr_Ingredient ingredient)
    {
        if(ingredient == null) { Debug.LogError("Got a null ingredient"); }

        currentIngredient = ingredient;
        image.enabled = true;
        image.sprite = currentIngredient.Sprite;
        label.text = currentIngredient.Name;
        Debug.Log("Set ingredient to " + ingredient.Name);
        dragable.EnableDragging();
    }

    public void UnsetIngredient()
    {
        currentIngredient = null;
        image.enabled = false;
        label.text = "";
        dragable.DisableDragging();
    }

}
