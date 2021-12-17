using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character2DController : MonoBehaviour
{
	public float MovementSpeed = 1;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var moveX = Input.GetAxisRaw("Horizontal");
		var moveY = Input.GetAxisRaw("Vertical");
		transform.position += new Vector3(moveX, moveY, 0) * Time.deltaTime * MovementSpeed;
    }


}
