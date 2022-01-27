using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject Candle;
    public GameObject CandlelightBorder;


    public GameObject Flashlight;
    public GameObject FlashlightInventory;
    public GameObject FlashlightBorder;

    public GameObject Flashlight2;
    public GameObject Flashlight2Inventory;
    public GameObject Flashlight2Border;
    public GameObject Flashlight2Concave; // Holle lens
    public GameObject Flashlight2Convex;  // Bolle lens

    public GameObject Flashlight2ConcaveHold; // Holle lens
    public GameObject Flashlight2ConvexHold;  // Bolle lens

    public bool unlockFlash = false;
    public bool unlockFlash2 = false;
    public bool unlockFlash2Concave = false;
    public bool unlockFlash2Convex = false;

    public bool flash2Disabled = false;


    [HideInInspector]
    public bool candleEquip = true;
    [HideInInspector] 
    public bool flashlightEquip = false;
    [HideInInspector] 
    public bool flashlight2Equip = false;
    [HideInInspector] 
    public bool concaveEquip = false;
    [HideInInspector] 
    public bool convexEquip = false;
    [HideInInspector] 
    public bool hasKey = false;

    private PlayerAttributes attr;
    private int lightCycle = 0;

    void Start(){
        attr = gameObject.GetComponent<PlayerAttributes>();
    }
    // Show the frame/border of the flashlight
    public void FlashInvOn(){
        FlashlightInventory.SetActive(true);
    }
    // Show the frame/border of the flashlight2
    public void Flash2InvOn(){
        Flashlight2Inventory.SetActive(true);
    }

    // This will equip the player with the concave lens and disable the other.
    public void ConcaveInvActive(){
        concaveEquip = true;
        if(unlockFlash2Convex){
            Flashlight2Convex.SetActive(false);
            Flashlight2ConvexHold.SetActive(false);
            convexEquip = false;
        }
        Flashlight2ConcaveHold.SetActive(false);
        Flashlight2Concave.SetActive(!Flashlight2Concave.activeSelf);
        attr.UseFlashlight2Mode(1);
    }
    // This will equip the player with the convex lens and disable the other.
    public void ConvexInvActive(){
        convexEquip = true;    
        if(unlockFlash2Concave){
            Flashlight2Concave.SetActive(false);
            Flashlight2ConcaveHold.SetActive(true);
            concaveEquip = false;
        }
        Flashlight2ConvexHold.SetActive(false);
        Flashlight2Convex.SetActive(!Flashlight2Convex.activeSelf);
        attr.UseFlashlight2Mode(2);
    }

    // This will check every update if a key has been pressed, if pressed activate the desired item
    void Update()
    {
        if(Input.GetKeyDown("1")){
            FlashOff();
            CandleInvActive();
            Flash2Off();
        }
        else if (Input.GetKeyDown("2") && unlockFlash){
            CandleOff();
            FlashInvActive();
            Flash2Off();
        }
        else if (Input.GetKeyDown("3") && unlockFlash2 && !flash2Disabled){
            CandleOff();
            FlashOff();
            Flash2InvActive();
        }else if (Input.GetKeyDown("q")){
            if(lightCycle == 0){
                attr.UseFlashlight2Mode(0);
                Flashlight2Convex.SetActive(false);
                Flashlight2Concave.SetActive(false);
                if(unlockFlash2Convex){
                    Flashlight2ConvexHold.SetActive(true);
                }
                Flashlight2ConcaveHold.SetActive(false);
                convexEquip = false;
                concaveEquip = false;
                lightCycle++;
            }else if(unlockFlash2Convex && lightCycle == 1){
                ConvexInvActive();
                if(!unlockFlash2Concave){
                    lightCycle = 0;
                }else{
                    lightCycle++;
                }
            }else if((unlockFlash2Concave && lightCycle == 2) || (unlockFlash2Concave && !unlockFlash2Convex && lightCycle == 1)){
                ConcaveInvActive();
                lightCycle = 0;
            }
        }
    }


    // These active functions will activate and highlight the desired item

    void CandleInvActive(){
        Candle.SetActive(!Candle.activeSelf);
        candleEquip = Candle.activeSelf;
        if(candleEquip){
            CandlelightBorder.GetComponent<SpriteRenderer>().color = Color.red;
        }else{
            CandlelightBorder.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    void FlashInvActive(){
        Flashlight.SetActive(!Flashlight.activeSelf);
        flashlightEquip = Flashlight.activeSelf;
        if(flashlightEquip){
            FlashlightBorder.GetComponent<SpriteRenderer>().color = Color.red;
        }else{
            FlashlightBorder.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    void Flash2InvActive(){
        Flashlight2.SetActive(!Flashlight2.activeSelf);
        flashlight2Equip = Flashlight2.activeSelf;
        if(flashlight2Equip){
            Flashlight2Border.GetComponent<SpriteRenderer>().color = Color.red;
        }else{
            Flashlight2Border.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    // These off functions will turn off the item
    void FlashOff(){
        Flashlight.SetActive(false);
        flashlightEquip = false;
        FlashlightBorder.GetComponent<SpriteRenderer>().color = Color.white;
    }

    void Flash2Off(){
        if(!flash2Disabled){
            Flashlight2.SetActive(false);
            flashlight2Equip = false;
            Flashlight2Border.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    void CandleOff(){
        Candle.SetActive(false);
        candleEquip = false;
        CandlelightBorder.GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void Flash2InvOff(){
        Flashlight2.SetActive(false);
        flashlight2Equip = false;
        Flashlight2Inventory.SetActive(false);
    }
}