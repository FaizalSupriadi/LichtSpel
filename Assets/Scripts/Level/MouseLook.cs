using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MouseLook : MonoBehaviour
{
	public float mouseSensitivity = 100f;
	float xRotation = 0f;
	float yRotation = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // This handles the camera look and walking
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
       
        xRotation -= mouseY;
        yRotation += mouseX;

        if (yRotation > 0.5 ){
        	transform.localRotation = Quaternion.Euler(0.0f, 0, -xRotation);
        }else if(yRotation < 0.5){
        	transform.localRotation = Quaternion.Euler(0.0f, 180, -xRotation);

        }
    }
}
