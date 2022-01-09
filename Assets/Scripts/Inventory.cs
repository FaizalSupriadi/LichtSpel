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

    [HideInInspector]
    public bool unlockFlash = false;

    public bool candleEquip = true;
    public bool flashlightEquip = false;

    public void FlashInvOn(){
		FlashlightInventory.SetActive(true);
    }

    // Use desired objects
    void Update()
    {
        if(Input.GetKeyDown("1")){
        	FlashOff();
			CandleInvActive();
        }
        else if (Input.GetKeyDown("2") && unlockFlash){
        	CandleOff();
			FlashInvActive();
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

     void CandleOff(){
    	Candle.SetActive(false);
		candleEquip = false;
		CandlelightBorder.GetComponent<SpriteRenderer>().color = Color.white;

    }

}
