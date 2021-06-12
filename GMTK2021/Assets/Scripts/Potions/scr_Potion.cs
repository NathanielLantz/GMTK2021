using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Potion", menuName ="ScriptableObject/Potion")]
public class scr_Potion : ScriptableObject
{
    [SerializeField]
    new string name;
    public string Name => name;

    [SerializeField]
    [Tooltip("Required ingredients to make this potion. Ingredients cannot repeat, and 3 must be entered")]
    scr_Ingredient ingredient1;
    public scr_Ingredient Ingredient1 => ingredient1;

    [SerializeField]
    [Tooltip("Required ingredients to make this potion. Ingredients cannot repeat, and 3 must be entered")]
    scr_Ingredient ingredient2;
    public scr_Ingredient Ingredient2 => ingredient2;

    [SerializeField]
    [Tooltip("Required ingredients to make this potion. Ingredients cannot repeat, and 3 must be entered")]
    scr_Ingredient ingredient3;
    public scr_Ingredient Ingredient3 => ingredient3;
}
