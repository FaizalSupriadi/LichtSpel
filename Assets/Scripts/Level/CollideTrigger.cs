using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CollideTrigger : MonoBehaviour
{
    public GameObject BridgeHitbox;
    public GameObject GlobalLight;
    public GameObject GlobalLightDark;

    private SensorInteract sensor;
    private Dialogue dialogue;
    private PlayerAttributes attr;
    private Inventory inventory;
    void Start(){
        attr = gameObject.GetComponent<PlayerAttributes>();
        inventory = gameObject.GetComponent<Inventory>();
    }

    // When colliding with another object, if the name is correct, it does something specific
    private void OnTriggerEnter2D(Collider2D collider){ 
        Debug.Log(collider.gameObject.tag);
        dialogue = collider.gameObject.GetComponent<Dialogue>();
        

        if(collider.CompareTag("Flashlight")){

            startDialogue();
            collider.gameObject.SetActive(false);
            inventory.unlockFlash = true;
            inventory.FlashInvOn();

        }else if(collider.CompareTag("Flashlight2")){

            startDialogue();
            collider.gameObject.SetActive(false);
            inventory.unlockFlash2 = true;
            inventory.Flash2InvOn();

        }
        else if(collider.CompareTag("Battery")){

            if(inventory.unlockFlash){
                attr.UpgradeFlashlightIntensity();
                if(attr.GetFlashlightIntensity() == 2){
                    dialogue.setDialogue("Nog maar 1 batterij te gaan!");
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
            if(attr.GetFlashlightIntensity() <= 2 || !inventory.flashlightEquip){
                startDialogue();
            }else{
                BridgeHitbox.SetActive(false);
            }

        }else if(collider.CompareTag("Sign")){
            startDialogue();

        }else if(collider.CompareTag("Sensor")){
            
            sensor = collider.gameObject.GetComponent<SensorInteract>();
            if(inventory.flashlight2Equip){
                sensor.activate();
                dialogue.setDialogue("Yes! Ik hoor een deur die open gaat!");
            }
            startDialogue();
            
        }
        else if(collider.CompareTag("End")){
            Cursor.lockState = CursorLockMode.None;
            SceneSwitcher.next();
            // startDialogue();
            // GlobalLight.SetActive(true);
            // GlobalLightDark.SetActive(false);
        }
        else if(collider.CompareTag("Sign")){
            startDialogue();
        }else if(collider.CompareTag("Key")){
            startDialogue();
            inventory.hasKey = true;
            collider.gameObject.SetActive(false);
        }else if(collider.CompareTag("End2")){
            if(inventory.hasKey){            
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                SceneSwitcher.next();
            }else{
                startDialogue();
            }
        }
    }

    private void startDialogue(){
        if(dialogue != null){
            StartCoroutine(dialogue.StartDialogue());
        }
    }

    private void OnTriggerExit2D(Collider2D collider){
        if(dialogue != null){
            StartCoroutine(dialogue.StopDialogue());
            dialogue = null;
        }
    }
}