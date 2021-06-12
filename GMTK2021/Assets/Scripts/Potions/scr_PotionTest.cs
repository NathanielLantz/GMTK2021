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

    // Start is called before the first frame update
    void Start()
    {
        targetText.text = targetPotion.Name;
        resultText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            potionManager.SelectIngredient(a);
        }
        if(Input.GetKeyDown(KeyCode.B))
        {
            potionManager.SelectIngredient(b);

        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            potionManager.SelectIngredient(c);

        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            potionManager.SelectIngredient(d);
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            potionManager.SelectIngredient(e);

        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            potionManager.SelectIngredient(f);

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
