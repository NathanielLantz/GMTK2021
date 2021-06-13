using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetablePotionBrewing : MonoBehaviour, TargetableObject
{

    public string DescriptiveText => "Brew Potion (LMB)";

    public void Interact(DescriptiveTextController controller)
    {
        if(controller.CurrentIngredient == null)
        {
            return;
        }

        Debug.Log("start potion");
        scr_PotionUI.Instance.SetNextIngredient(controller.CurrentIngredient);
        scr_PotionUI.Instance.ShowPotionUI();
        controller.ResetIngredient();
        controller.AllowMouse();
    }

}
