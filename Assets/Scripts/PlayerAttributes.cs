using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerAttributes : MonoBehaviour
{
	public static GameObject FlashLight;

	private static int FlashlightIntensity = 0;

    public static int GetFlashlightIntensity(){
    	return FlashlightIntensity;
    }

    public static void UpgradeFlashlightIntensity(){
    	FlashlightIntensity += 1;
    	Debug.Log(FlashlightIntensity);
    	// FlashLight.GetComponent<Light2D>().OuterRadius += 1;

    	if(FlashlightIntensity > 3){
    		FlashlightIntensity = 3;
    	}
    }

}
