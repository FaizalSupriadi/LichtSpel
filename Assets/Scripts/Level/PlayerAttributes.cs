using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerAttributes : MonoBehaviour
{
	public  GameObject FlashlightIntensityOne;
    public  GameObject FlashlightIntensityTwo;
    public  GameObject FlashlightIntensityThree;

	public int FlashlightIntensity;

    void Start(){
        UpgradeFlashlightIntensity();
    }

    public int GetFlashlightIntensity(){
    	return FlashlightIntensity;
    }

    public void UpgradeFlashlightIntensity(){
    	FlashlightIntensity += 1;
    	Debug.Log(FlashlightIntensity);
    	if(FlashlightIntensity == 1){
    		FlashlightIntensityOne.SetActive(true);
    		FlashlightIntensityTwo.SetActive(false);
    		FlashlightIntensityThree.SetActive(false);
    	}
    	else if(FlashlightIntensity == 2){
    		FlashlightIntensityOne.SetActive(false);
    		FlashlightIntensityTwo.SetActive(true);
    		FlashlightIntensityThree.SetActive(false);
    	}
    	else if(FlashlightIntensity == 3){
    		FlashlightIntensityOne.SetActive(false);
    		FlashlightIntensityTwo.SetActive(false);
    		FlashlightIntensityThree.SetActive(true);
    	}
    	if(FlashlightIntensity > 3){
    		FlashlightIntensity = 3;
    	}
    }

}
