using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CollideTrigger : MonoBehaviour
{
	public GameObject BridgeHitbox;
	public GameObject GlobalLight;
	public GameObject GlobalLightDark;

	private Dialogue dialogue;
	private PlayerAttributes attr;
	void Start(){
		attr = gameObject.GetComponent<PlayerAttributes>();

	}

	// When colliding with another object, if the name is correct, it does something specific
    private void OnTriggerEnter2D(Collider2D collider){	
    	Debug.Log(collider.gameObject.tag);
		dialogue = collider.gameObject.GetComponent<Dialogue>();

    	if(collider.CompareTag("Flashlight")){
			startDialogue();
    		collider.gameObject.SetActive(false);
    		Inventory.unlockFlash = true;
    	}else if(collider.CompareTag("Battery")){
    		if(Inventory.unlockFlash){
    			attr.UpgradeFlashlightIntensity();
    			if(attr.GetFlashlightIntensity() == 2){
    				dialogue.setDialogue("Nog maar 1 batterij!");
    				startDialogue();
    			}else if(attr.GetFlashlightIntensity() > 2){
    				dialogue.setDialogue("Ik heb nu 2 batterijen.... Mijn lichtbron is nu sterk genoeg om goed te kunnen zien over welke brug ik moet lopen om aan de overkant te komen.");
    				startDialogue();
    			}
    			collider.gameObject.SetActive(false);
    		}else{
    			startDialogue();
    		}
    	}else if(collider.CompareTag("Bridge")){
    		if(attr.GetFlashlightIntensity() <= 2 || !Inventory.flashlightEquip){
				startDialogue();
    		}else{
    			BridgeHitbox.SetActive(false);
    		}
    	}else if(collider.CompareTag("Sign")){
			startDialogue();
    	}else if(collider.CompareTag("End")){
			startDialogue();
			GlobalLight.SetActive(true);
			GlobalLightDark.SetActive(false);

    	}
    }

    private void startDialogue(){
    	if(dialogue != null){
			dialogue.StartDialogue();
		}
    }

    private void OnTriggerExit2D(Collider2D collider){
    	if(dialogue != null){
			StartCoroutine(dialogue.StopDialogue());
			dialogue = null;
		}
    }
}
