using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scr_PotionTest : MonoBehaviour
{
    [SerializeField]
    scr_Potion targetPotion;

    [Space]

    [SerializeField]
    scr_PotionManager potionManager;

    [SerializeField]
    scr_PotionUI potionUI;

    [SerializeField]
    TextMeshProUGUI targetText;

    [SerializeField]
    TextMeshProUGUI resultText;

    [SerializeField]
    List<scr_Ingredient> ingredients;

    Queue<scr_Ingredient> ingredientsToTest;

    // Start is called before the first frame update
    void Start()
    {
        targetText.text = targetPotion.Name;
        resultText.text = "";

        ingredientsToTest = new Queue<scr_Ingredient>();
        foreach(scr_Ingredient ingredient in ingredients)
        {
            ingredientsToTest.Enqueue(ingredient);
        }

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {

            if (ingredientsToTest.Peek() == null) { return; }
            scr_Ingredient ingredient = ingredientsToTest.Dequeue();
            potionUI.SetNextIngredient(ingredient);
            ingredientsToTest.Enqueue(ingredient);
        }
    }

    public void PotionManager_OnPotionComplete(scr_Potion potionCreated)
    {
        if (potionCreated == targetPotion)
        {
            resultText.text = "Success";
        }
        else
        {
            resultText.text = "Failure";
        }
    }

}
