using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DescriptiveTextController : MonoBehaviour
{
    [SerializeField]
    Camera camera;

    [SerializeField]
    LayerMask targetableMask;

    [SerializeField]
    TextMeshProUGUI descriptiveText;

    void Update()
    {
        descriptiveText.text = "";

        RaycastHit hit;
        
        if (Physics.Raycast(camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0)), out hit, 20)){
            TargetableObject tagetableObject = hit.collider.gameObject.GetComponent<TargetableObject>();
            if (tagetableObject != null)
            {
                Debug.Log(tagetableObject.Ingredient.Name);
                descriptiveText.text = tagetableObject.Ingredient.Name;
            }
        }

    }
}
