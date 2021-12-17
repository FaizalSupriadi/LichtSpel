using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Candle;
    public GameObject Flashlight;
    [HideInInspector]
    public static bool unlockFlash = false ;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("1")){
        	Candle.SetActive(!Candle.activeSelf);
        }
        else if (Input.GetKeyDown("2") && unlockFlash){
        	Flashlight.SetActive(!Flashlight.activeSelf);
        }
    }
}
