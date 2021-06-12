using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class PotionCreatedEvent : UnityEvent<scr_Potion> { }
[System.Serializable]
public class IngredientSelectedEvent : UnityEvent<int, scr_Ingredient> { }

public class scr_PotionManager : MonoBehaviour
{
    [SerializeField]
    PotionCreatedEvent OnPotionCreated;
    [SerializeField]
    IngredientSelectedEvent OnIngredientsSelected;
    [SerializeField]
    UnityEvent OnIngredientsCleared;
    [SerializeField]
    UnityEvent OnIngredientsSelectionComplete;


    [SerializeField]
    scr_Potion[] potions;

    [SerializeField]
    scr_Potion badPotion;

    List<scr_Ingredient> ingredients;

    private void Awake()
    {
        ingredients = new List<scr_Ingredient>();
    }


    public bool SelectIngredient(scr_Ingredient ingredient)
    {
        if(ingredients.Count == 3)
        {
            Debug.LogError("<b>Potion Manager: </b>Attempted to add more than 3 ingredients.");
            return false;
        }

        if(ingredients.Contains(ingredient))
        {
            Debug.Log("<b>Potion Manager: </b>Attempted to add the same ingredient twice.");
            return false;
        }

        ingredients.Add(ingredient);
        OnIngredientsSelected?.Invoke(ingredients.Count - 1, ingredient);

        if(ingredients.Count == 3)
        {
            OnIngredientsSelectionComplete?.Invoke();
        }

        return true;
    }

    public void ClearIngredients()
    {
        ingredients.Clear();
        OnIngredientsCleared?.Invoke();
    }

    public void AttemptMakePotion()
    {
        scr_Potion potionCreated = badPotion;

        foreach (scr_Potion potion in potions) {
            List<scr_Ingredient> requiredIngredients = new List<scr_Ingredient>
            {
                potion.Ingredient1,
                potion.Ingredient2,
                potion.Ingredient3
            };

            bool madeAPotion = true;

            foreach(scr_Ingredient ingredient in requiredIngredients)
            {
                if(!ingredients.Contains(ingredient))
                {
                    madeAPotion = false;
                    break;
                }
            }

            if (madeAPotion)
            {
                potionCreated = potion;
                break;
            }

        }

        ClearIngredients();
        OnPotionCreated?.Invoke(potionCreated);
    }

}
