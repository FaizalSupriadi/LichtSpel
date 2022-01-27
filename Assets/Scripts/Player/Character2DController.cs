using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character2DController : MonoBehaviour
{
	public float MovementSpeed = 70;

	private Rigidbody2D body;

	void Start(){
		body = gameObject.GetComponent<Rigidbody2D>();
	}
	
    // Get keyboard input and use those to move the player
    void Update()
    {
        var moveX = Input.GetAxisRaw("Horizontal");
		var moveY = Input.GetAxisRaw("Vertical");
		body.MovePosition( new Vector2(
			(transform.position.x + moveX * Time.deltaTime * MovementSpeed), 
			(transform.position.y + moveY * Time.deltaTime * MovementSpeed)
			));
    }


}
