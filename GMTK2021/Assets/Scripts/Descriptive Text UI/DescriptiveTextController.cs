using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public interface TargetableObject
{
    string DescriptiveText { get; }
    void Interact(DescriptiveTextController controller);
}

public class DescriptiveTextController : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField]
    float distance = 2;

    [Header("Sound Effects")]
    [SerializeField]
    AudioClip ingredientPickedUpSFX;

    [SerializeField]
    AudioClip ingredientDroppedSFX;

    [Header("References")]
    [SerializeField]
    Camera mainCamera;

    [SerializeField]
    TextMeshProUGUI descriptiveText;

    scr_Ingredient currentIngredient;
    public scr_Ingredient CurrentIngredient => currentIngredient;
    scr_Potion currentPotion;
    public scr_Potion CurrentPotion => currentPotion;

    void Update()
    {
        descriptiveText.text = "";

        RaycastHit hit;
        
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);
        if (Physics.Raycast(ray, out hit, distance)){
            TargetableObject targetableObject = hit.collider.gameObject.GetComponent<TargetableObject>();
            if (targetableObject != null)
            {
                descriptiveText.text = targetableObject.DescriptiveText;
                if (Input.GetMouseButtonDown(0))
                {
                    targetableObject.Interact(this);
                }
            }

        }

        if(currentIngredient != null)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("dropped " + currentIngredient.Name);
                currentIngredient = null;
                scr_AudioManager.PlaySoundEffect(ingredientDroppedSFX);
            }
        }

    }

    public void SetCurrentIngredient(scr_Ingredient ingredient)
    {
        Debug.Log("picked up " + ingredient.Name);
        currentIngredient = ingredient;
        scr_AudioManager.PlaySoundEffect(ingredientPickedUpSFX);
        
    }
}
