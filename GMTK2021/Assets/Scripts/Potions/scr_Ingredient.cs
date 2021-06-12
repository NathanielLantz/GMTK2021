using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ingredient", menuName = "ScriptableObject/Ingredient")]
public class scr_Ingredient : ScriptableObject
{
    [SerializeField]
    new string name;
    public string Name => name;
}
