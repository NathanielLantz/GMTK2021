using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scr_PotionUI : MonoBehaviour
{
    [SerializeField]
    scr_PotionManager potionManager;

    [SerializeField]
    Button makePotionButton;
    [SerializeField]
    Button clearIngredientsButton;

    [SerializeField]
    TextMeshProUGUI ingredientText0;
    [SerializeField]
    TextMeshProUGUI ingredientText1;
    [SerializeField]
    TextMeshProUGUI ingredientText2;
    [SerializeField]
    TextMeshProUGUI potionText;

    private void Start()
    {
        makePotionButton.interactable = false;
        clearIngredientsButton.interactable = false;

        ingredientText0.text = "";
        ingredientText1.text = "";
        ingredientText2.text = "";
        potionText.text = "";
    }

    public void PotionMaker_OnClear()
    {
        makePotionButton.interactable = false;
        clearIngredientsButton.interactable = false;

        ingredientText0.text = "";
        ingredientText1.text = "";
        ingredientText2.text = "";

    }

    public void PotionMaker_OnIngredientSelected(int slot, scr_Ingredient ingredient)
    {
        switch(slot)
        {
            case 0:
                ingredientText0.text = ingredient.Name; break;
            case 1:
                ingredientText1.text = ingredient.Name; break;
            case 2:
                ingredientText2.text = ingredient.Name; break;
        }
        clearIngredientsButton.interactable = true;
    }

    public void PotionMaker_OnIngredientsSelectionComplete()
    {
        makePotionButton.interactable = true;
    }

    public void PotionManager_OnPotionCreated(scr_Potion potionCreated)
    {
        potionText.text = potionCreated.Name;
    }

    public void PotionMakeButton_OnClick()
    {
        potionManager.AttemptMakePotion();
    }

    public void ClearButton_OnClick()
    {
        potionManager.ClearIngredients();
    }
}
