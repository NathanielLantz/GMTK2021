using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetableIngredient: MonoBehaviour, TargetableObject
{
    [SerializeField]
    scr_Ingredient ingredient;
    public scr_Ingredient Ingredient => ingredient;

    public string DescriptiveText => "Pick up " + ingredient.Name + " (LMB)";

    public void Interact(DescriptiveTextController controller)
    {
        controller.SetCurrentIngredient(ingredient);
    }


}
