using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveCollide : MonoBehaviour
{
	public int objective = 0;
	private bool done = false;

    public int getObjective(){
    	if(done){ return -1;}
    	done = true;
    	return objective;
    }
}
