using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Potion", menuName ="ScriptableObject/Potion")]
public class scr_Potion : ScriptableObject
{
    [SerializeField]
    new string name;

    [SerializeField]
    [Tooltip("Required ingredients to make this potion. Ingredients cannot repeat, and 3 must be entered")]
    scr_Ingredient ingredient1;

    [SerializeField]
    [Tooltip("Required ingredients to make this potion. Ingredients cannot repeat, and 3 must be entered")]
    scr_Ingredient ingredient2;

    [SerializeField]
    [Tooltip("Required ingredients to make this potion. Ingredients cannot repeat, and 3 must be entered")]
    scr_Ingredient ingredient3;
}
