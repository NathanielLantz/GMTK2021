using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class scr_ApplyColourToSprite
{
    public static void ApplyColour(ref Sprite sprite, Texture2D originalTexture, Texture2D mask, Color colourToApply)
    {

        Texture2D modifiedTexture = new Texture2D(originalTexture.width, originalTexture.height, TextureFormat.RGBA32, true);

        Color[] baseColours = originalTexture.GetPixels();
        Color[] maskColours = mask.GetPixels();

        //apply colours
        for(int i = 0; i < baseColours.Length; i++)
        {
            
            if (maskColours[i].Equals(Color.white))
            {
                baseColours[i].r = baseColours[i].r * colourToApply.r;
                baseColours[i].g = baseColours[i].g * colourToApply.g;
                baseColours[i].b = baseColours[i].b * colourToApply.b;
            }
        }

        modifiedTexture.SetPixels(baseColours);
        modifiedTexture.Apply();
        Sprite s = Sprite.Create(modifiedTexture, new Rect(0, 0, modifiedTexture.width, modifiedTexture.height), new Vector2(0.5f, 0.5f));
        sprite = s;
    }
}
