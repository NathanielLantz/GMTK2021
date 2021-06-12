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
    scr_Ingredient a;
    [SerializeField]
    scr_Ingredient b;
    [SerializeField]
    scr_Ingredient c;
    [SerializeField]
    scr_Ingredient d;
    [SerializeField]
    scr_Ingredient e;
    [SerializeField]
    scr_Ingredient f;

    Queue<scr_Ingredient> ingredientsToTest;

    // Start is called before the first frame update
    void Start()
    {
        targetText.text = targetPotion.Name;
        resultText.text = "";

        ingredientsToTest = new Queue<scr_Ingredient>();
        ingredientsToTest.Enqueue(a);
        ingredientsToTest.Enqueue(b);
        ingredientsToTest.Enqueue(c);
        ingredientsToTest.Enqueue(d);
        ingredientsToTest.Enqueue(e);
        ingredientsToTest.Enqueue(f);

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
