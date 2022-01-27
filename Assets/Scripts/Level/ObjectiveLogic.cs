using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectiveLogic : MonoBehaviour
{

	public TMP_Text ObjectiveText;
	public List<string> objectives;


	private int currentObjective = 0;

    void Update()
    {
        ObjectiveText.text = objectives[currentObjective];
    }

    public void goToObjective(int task){
    	if (task < 0){}
    	else if(task < objectives.Count && currentObjective < task){
    		currentObjective = task;
    	}
    }

    public void nextObjective(){
    	if(currentObjective + 1 < objectives.Count){
    		currentObjective += 1;
    	}
    	
    }

}
