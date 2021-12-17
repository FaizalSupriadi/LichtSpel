using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider){	
    	Debug.Log(collider.gameObject.name);
    	if(collider.gameObject.name == "Flashlight"){
    		collider.gameObject.SetActive(false);
    		Inventory.unlockFlash = true;
    	}
    }
}
