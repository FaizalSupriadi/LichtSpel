using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject Candle;

    public GameObject Flashlight;


    [HideInInspector]
    public static bool unlockFlash = false;

    public static bool candleEquip = true;
    public static bool flashlightEquip = false;

    // Use desired objects
    void Update()
    {
        if(Input.GetKeyDown("1")){
        	FlashOff();
        	Candle.SetActive(!Candle.activeSelf);
        	candleEquip = Candle.activeSelf;
        }
        else if (Input.GetKeyDown("2") && unlockFlash){
        	CandleOff();
        	Flashlight.SetActive(!Flashlight.activeSelf);
        	flashlightEquip = Flashlight.activeSelf;
        }
    }

    void FlashOff(){
    	Flashlight.SetActive(false);
		flashlightEquip = false;
    }

     void CandleOff(){
    	Candle.SetActive(false);
		candleEquip = false;
    }

}
