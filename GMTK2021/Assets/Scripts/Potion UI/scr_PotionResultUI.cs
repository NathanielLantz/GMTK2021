using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct PotionBottleTexture
{
    public Texture2D originalTexture;

    public Texture2D mask;

}
public class scr_PotionResultUI : MonoBehaviour
{
    [SerializeField]
    AudioClip potionCreatedSFX;

    [SerializeField]
    Image image;

    [SerializeField]
    PotionBottleTexture[] potionBottleTextures;


    public void PotionManager_OnPotionCreated(scr_Potion potion)
    {
        SetColour(potion.Colour);
    }

    public void SetColour(Color colour)
    {
        Sprite sprite = image.sprite;
        scr_ApplyColourToSprite.ApplyColour(ref sprite, potionBottleTextures[0].originalTexture, potionBottleTextures[0].mask, colour);
        image.sprite = sprite;
    }

}
