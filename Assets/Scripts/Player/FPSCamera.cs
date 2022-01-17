using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    public Camera FPSCam;

    public float horizontalSpeed;
    public float verticalSpeed;

    float h;
    float v;

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        h = horizontalSpeed * Input.GetAxis("Mouse X");
        v = verticalSpeed * Input.GetAxis("Mouse Y");

        transform.Rotate(0,h,0);
        FPSCam.transform.Rotate(-v,0,0);

        if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0,0, horizontalSpeed *-0.1f);
        }
        else{
            if(Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(0,0, horizontalSpeed*0.1f);
            }
        }
    }
}
