using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerRotation : MonoBehaviour
{

    void Start()
    {
    	Cursor.lockState = CursorLockMode.Locked;
    }

    // This handles the camera look and walking
    void Update()
    {

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) ){
            transform.localRotation = Quaternion.Euler(0.0f, 0, 90);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
            transform.localRotation = Quaternion.Euler(0.0f, 180, 0);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)){
            transform.localRotation = Quaternion.Euler(0.0f, 0, -90);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
            transform.localRotation = Quaternion.Euler(0.0f, 0, 0);
        }
    }
}