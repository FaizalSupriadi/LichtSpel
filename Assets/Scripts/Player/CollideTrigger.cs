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

    // // When colliding and staying on another object, if the tag is correct, it does something specific
    private void OnTriggerStay2D(Collider2D collider){ 
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
        }else if(collider.CompareTag("Concave")){
            concave(collider);
        }else if(collider.CompareTag("Convex")){
            convex(collider);
        }else if(collider.CompareTag("End")){
            end(collider);
        }else if(collider.CompareTag("End2")){
            end2(collider);
        }
    }
    // Start a dialogue that is written in the colliding script
    private void startDialogue(){
        if(dialogue != null){
            StartCoroutine(dialogue.StartDialogue());
        }
    }

    // When the player moves away from the collision, stop the dialogue aswell
    private void OnTriggerExit2D(Collider2D collider){
        if(dialogue != null){
            StartCoroutine(dialogue.StopDialogue());
            dialogue = null;
        }
    }
    // Will pickup the first flashlight and unlock it
    void flashlight(Collider2D collider){
        startDialogue();
        collider.gameObject.SetActive(false);
        inventory.unlockFlash = true;
        inventory.FlashInvOn();
        objLogic.nextObjective();
    }
    // Will pickup the second flashlight and unlock it
    void flashlight2(Collider2D collider){
        objLogic.goToObjective(task.getObjective());
        startDialogue();
        collider.gameObject.SetActive(false);
        inventory.unlockFlash2 = true;
        inventory.Flash2InvOn();
    }
    // The battery will upgrade the first flashlight's light
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
    // This checks whether the player has a strong enough light to go over it.
    void bridge(Collider2D collider){
        if(attr.GetFlashlightIntensity() <= 2 || !inventory.flashlightEquip){
            startDialogue();
        }else{
            BridgeHitbox.SetActive(false);
        }
    }
    // The sensor will check for multiple possibilties with the lenses and its flashlight
    void sensor(Collider2D collider){
        sensor_ = collider.gameObject.GetComponent<SensorInteract>();
        if(inventory.flashlight2Equip && inventory.convexEquip && Input.GetKey("e") && inventory.unlockFlash2Concave){
            inventory.flash2Disabled = true;
            objLogic.nextObjective();
            sensor_.activate();
            dialogue.setDialogue("Yes! Ik hoor een deur die open gaat!");
        }else if(inventory.flashlight2Equip && inventory.concaveEquip && Input.GetKey("e") && inventory.unlockFlash2Concave && inventory.unlockFlash2Convex){
            dialogue.setDialogue("De bolle lens schijnt niet het juiste licht voor de sensor!");
        }else if(inventory.flashlight2Equip && !inventory.convexEquip && !inventory.concaveEquip && Input.GetKey("e") && inventory.unlockFlash2Concave && inventory.unlockFlash2Convex){
            dialogue.setDialogue("Je hebt geen lens gebruikt!");
        }else if(inventory.unlockFlash2 && !inventory.unlockFlash2Concave && !inventory.unlockFlash2Convex){
            dialogue.setDialogue("Ik heb nog een holle en bolle lens nodig!");
        }else if(inventory.unlockFlash2 && !inventory.unlockFlash2Concave){
            dialogue.setDialogue("Ik heb nog een holle lens nodig!");
        }else if(inventory.unlockFlash2 && !inventory.unlockFlash2Convex){
            dialogue.setDialogue("Ik heb nog een bolle lens nodig!");
        }else if(inventory.flashlight2Equip && inventory.unlockFlash2Convex && inventory.unlockFlash2Convex){
            dialogue.setDialogue("Plaats hier de zaklamp. Met Q kan ik wisselen tussen de lensen en met E kan ik het neerplaatsen!");
        }else{
            objLogic.goToObjective(task.getObjective());
        }
        startDialogue();
    }
    // This will unlock the end gate of level 2
    void key(Collider2D collider){
        objLogic.goToObjective(task.getObjective());
        startDialogue();
        inventory.hasKey = true;
        collider.gameObject.SetActive(false);
    }
    // The ending of level 1, will switch to the next scene
    void end(Collider2D collider){
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneSwitcher.next();
    }
    // The ending of level 2, will switch to the next scene
    void end2(Collider2D collider){
        if(inventory.hasKey){            
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneSwitcher.next();
        }else{
            startDialogue();
        }
    }
    // Will unlock the concave lens
    void concave(Collider2D collider){
        if(!inventory.unlockFlash2){
            startDialogue();
        }else{
            if(inventory.unlockFlash2Convex){
                objLogic.nextObjective();
            }
            dialogue.setDialogue("Hmmm... Ik denk dat dit de holle lens is!");
            startDialogue();
            inventory.unlockFlash2Concave = true;
            collider.gameObject.SetActive(false);
        }
    }
    // Will unlock the concave lens
    void convex(Collider2D collider){
        if(!inventory.unlockFlash2){
            startDialogue();
        }else{
            if(inventory.unlockFlash2Concave){
                objLogic.nextObjective();
            }
            dialogue.setDialogue("Hmmm... Ik denk dat dit de bolle lens is!");
            startDialogue();
            inventory.unlockFlash2Convex = true;
            collider.gameObject.SetActive(false);
        }
    }
}