using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetableCustomer : MonoBehaviour, TargetableObject
{
    public string DescriptiveText => "Give Potion (LMB)";

    public void Interact(DescriptiveTextController controller)
    {
        if(controller.CurrentPotion == null)
        {
            Debug.Log("Attempted to give null potion");
            return;
        }
        //give potion
        Debug.Log("Give the potion " + controller.CurrentPotion.Name);
        controller.ResetPotion();
    }

}
