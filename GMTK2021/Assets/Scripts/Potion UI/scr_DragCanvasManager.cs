using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_DragCanvasManager : MonoBehaviour
{
    
    private void Start()
    {
        Canvas canvas = GetComponent<Canvas>();

        scr_Dragable[] dragables = FindObjectsOfType<scr_Dragable>();

        foreach(scr_Dragable dragable in dragables)
        {
            dragable.SetCanvas(canvas);
            dragable.SetDragable(true);
        }
    }
}
