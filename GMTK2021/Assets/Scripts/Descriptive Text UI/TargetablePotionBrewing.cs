using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetablePotionBrewing : MonoBehaviour, TargetableObject
{

    public string DescriptiveText => "Brew Potion";

    public void Interact(DescriptiveTextController controller)
    {
        Debug.Log("start potion");
        scr_PotionUI.Instance.SetNextIngredient(controller.CurrentIngredient);
        scr_PotionUI.Instance.ShowPotionUI();
    }

}
