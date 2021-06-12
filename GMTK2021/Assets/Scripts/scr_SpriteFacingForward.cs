using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_SpriteFacingForward : MonoBehaviour
{
    private Camera playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        playerCamera = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(playerCamera.transform);

        //comment this line out if you want objects to rotate on the y axis.
        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
    }
}
