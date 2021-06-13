using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_PotionResultUITester : MonoBehaviour
{
    [Header("Pick either a colour or a potion")]
    [ContextMenuItem("Test Colour", "TestColour")]
    [SerializeField]
    Color colourToTest;

    [SerializeField]
    [ContextMenuItem("Test Potion", "TestPotion")]
    scr_Potion potionToTest;

    [Space]

    [SerializeField]
    scr_PotionResultUI potionResultUI;


    public void TestColour()
    {
        potionResultUI.SetColour(colourToTest);
    }
    public void TestPotion()
    {
        potionResultUI.SetColour(potionToTest.Colour);
    }
}
