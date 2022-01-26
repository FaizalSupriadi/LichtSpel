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

    public bool unlockFlash = false;
    public bool unlockFlash2 = false;
    public bool flash2Disabled = false;
    
    [HideInInspector]
    public bool candleEquip = true;
    [HideInInspector] 
    public bool flashlightEquip = false;
    [HideInInspector] 
    public bool flashlight2Equip = false;
    [HideInInspector] 
    public bool hasKey = false;


    public void FlashInvOn(){
        FlashlightInventory.SetActive(true);
    }

    public void Flash2InvOn(){
        Flashlight2Inventory.SetActive(true);
    }

    // Use desired objects
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
        else if (Input.GetKeyDown("3") && unlockFlash2){
            CandleOff();
            FlashOff();
            Flash2InvActive();
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

     void CandleInvActive(){
        Candle.SetActive(!Candle.activeSelf);
        candleEquip = Candle.activeSelf;
        if(candleEquip){
            CandlelightBorder.GetComponent<SpriteRenderer>().color = Color.red;
        }else{
            CandlelightBorder.GetComponent<SpriteRenderer>().color = Color.white;
        }
        

    }

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