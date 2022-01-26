using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CollideTrigger : MonoBehaviour
{
    public GameObject BridgeHitbox;
    public GameObject GlobalLight;
    public GameObject GlobalLightDark;
    public GameObject objCanvas;

    private SensorInteract sensor_;
    private Dialogue dialogue;
    private PlayerAttributes attr;
    private Inventory inventory;
    private ObjectiveLogic objLogic;
    private ObjectiveCollide task;
    void Start(){
        attr = gameObject.GetComponent<PlayerAttributes>();
        inventory = gameObject.GetComponent<Inventory>();
        objLogic = objCanvas.GetComponent<ObjectiveLogic>();
    }



    // When colliding with another object, if the name is correct, it does something specific
    private void OnTriggerEnter2D(Collider2D collider){ 
        Debug.Log(collider.gameObject.tag);
        dialogue = collider.gameObject.GetComponent<Dialogue>();
        task = collider.gameObject.GetComponent<ObjectiveCollide>();

        if(collider.CompareTag("Flashlight")){
            flashlight(collider);
        }else if(collider.CompareTag("Flashlight2")){
            flashlight2(collider);
        }else if(collider.CompareTag("Battery")){
            battery(collider);
        }else if(collider.CompareTag("Bridge")){
            bridge(collider);
        }else if(collider.CompareTag("Sign")){
            startDialogue();
        }else if(collider.CompareTag("Sensor")){
            sensor(collider);
        }else if(collider.CompareTag("Key")){
            key(collider);
        }else if(collider.CompareTag("End")){
            end(collider);
        }else if(collider.CompareTag("End2")){
            end2(collider);
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

    void flashlight(Collider2D collider){
        startDialogue();
        collider.gameObject.SetActive(false);
        inventory.unlockFlash = true;
        inventory.FlashInvOn();
        objLogic.nextObjective();
    }

    void flashlight2(Collider2D collider){
        objLogic.goToObjective(task.getObjective());
        startDialogue();
        collider.gameObject.SetActive(false);
        inventory.unlockFlash2 = true;
        inventory.Flash2InvOn();
    }

    void battery(Collider2D collider){
        if(inventory.unlockFlash){
            objLogic.nextObjective();
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
    }



    void bridge(Collider2D collider){
        if(attr.GetFlashlightIntensity() <= 2 || !inventory.flashlightEquip){
            startDialogue();
        }else{
            BridgeHitbox.SetActive(false);
        }
    }

    void sensor(Collider2D collider){
        sensor_ = collider.gameObject.GetComponent<SensorInteract>();
        if(inventory.unlockFlash2){
            objLogic.nextObjective();
            sensor_.activate();
            dialogue.setDialogue("Yes! Ik hoor een deur die open gaat!");
        }else{
            objLogic.goToObjective(task.getObjective());
        }
        startDialogue();
    }

    void key(Collider2D collider){
        objLogic.goToObjective(task.getObjective());
        startDialogue();
        inventory.hasKey = true;
        collider.gameObject.SetActive(false);
    }

    void end(Collider2D collider){
        Cursor.lockState = CursorLockMode.None;
        SceneSwitcher.next();
    }

    void end2(Collider2D collider){
        if(inventory.hasKey){            
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneSwitcher.next();
        }else{
            startDialogue();
        }
    }
}