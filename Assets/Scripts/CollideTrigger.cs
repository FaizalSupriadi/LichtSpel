using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideTrigger : MonoBehaviour
{
	private PlayerAttributes attr;
	void Start(){
		attr = gameObject.GetComponent<PlayerAttributes>();

	}

	// When colliding with another object, if the name is correct, it does something specific
    private void OnTriggerEnter2D(Collider2D collider){	
    	Debug.Log(collider.gameObject.tag);
    	if(collider.gameObject.tag == "Flashlight"){
    		collider.gameObject.SetActive(false);
    		Inventory.unlockFlash = true;
    	}else if(collider.gameObject.tag == "Battery"){
    		if(Inventory.unlockFlash){
    			collider.gameObject.SetActive(false);
    			attr.UpgradeFlashlightIntensity();
    		}else{
    			Debug.Log("Need a flashlight...");
    		}
    	}else if(collider.gameObject.tag == "Bridge"){
    		if(attr.GetFlashlightIntensity() <= 2 || !Inventory.flashlightEquip){
    			Debug.Log("It's too dark...");
    			//Stop Player
    		}
    		
    	}
    }
}
