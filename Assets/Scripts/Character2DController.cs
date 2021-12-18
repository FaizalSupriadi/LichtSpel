using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character2DController : MonoBehaviour
{
	public float MovementSpeed = 1;
	
    // Get keyboard input and use those to move the player
    void Update()
    {
        var moveX = Input.GetAxisRaw("Horizontal");
		var moveY = Input.GetAxisRaw("Vertical");
		transform.position += new Vector3(moveX, moveY, 0) * Time.deltaTime * MovementSpeed;
    }


}
