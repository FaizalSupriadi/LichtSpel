using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorInteract : MonoBehaviour
{
    public GameObject Gate;
    public GameObject Flashlight2;
    public GameObject player;
    private Inventory inventory;

    void Start(){
        inventory = player.GetComponent<Inventory>();
    }
    // This will put the flashlight on the ground and open the lower gate of level 2
    public void activate(){
        inventory.Flash2InvOff();
        Flashlight2.SetActive(true);
        Gate.SetActive(false);
    }
}
