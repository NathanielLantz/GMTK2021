using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetablePotionBrewing : MonoBehaviour, TargetableObject
{
    [SerializeField]
    scr_PotionManager potionManager;

    public string DescriptiveText => "Brew Potion";

    public void Interact(DescriptiveTextController controller)
    {
        scr_PotionUI.Instance.SetNextIngredient(controller.CurrentIngredient);
        scr_PotionUI.Instance.ShowPotionUI();
    }

}
