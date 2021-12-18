using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideTrigger : MonoBehaviour
{
	// When colliding with another object, if the name is correct, it does something specific
    private void OnTriggerEnter2D(Collider2D collider){	
    	Debug.Log(collider.gameObject.name);
    	if(collider.gameObject.name == "Flashlight"){
    		collider.gameObject.SetActive(false);
    		Inventory.unlockFlash = true;
    	}else if(collider.gameObject.name == "Battery"){
    		if(Inventory.unlockFlash){
    			collider.gameObject.SetActive(false);
    			PlayerAttributes.UpgradeFlashlightIntensity();
    		}else{
    			Debug.Log("Need a flashlight...");
    		}
    	}else if(collider.gameObject.name == "Bridge"){
    		if(PlayerAttributes.GetFlashlightIntensity() <= 2 || !Inventory.flashlightEquip){
    			Debug.Log("It's too dark...");
    			//Stop Player
    		}
    		
    	}
    }
}
