using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizLogic : MonoBehaviour
{

	public List<string> questions;
	public List<string> answerA;
	public List<string> answerB;

	public List<bool> validityA;
	public List<bool> validityB;

    public TMP_Text QuestionText;
    public Button ButtonA;
	public Button ButtonB;

	public TMP_Text textA;
	public TMP_Text textB;

	public GameObject winCanvas;

	private int questionIndex;
	private int questionAmount = 0;

	private ColorBlock colRed;
	private ColorBlock colNormal;
	// question[1] is why bijv

    void Start()
    {
        questionAmount = questions.Count;

		colNormal = ButtonA.colors;

		colRed = ButtonA.colors;
		colRed.disabledColor = Color.red;
		colRed.highlightedColor = Color.red;
		colRed.normalColor = Color.red;
		colRed.pressedColor= Color.red;
		colRed.selectedColor= Color.red;

    }

    // Update is called once per frame
    void Update()
    {
		QuestionText.text = questions[questionIndex];
		textA.text = answerA[questionIndex];
		textB.text = answerB[questionIndex];
    }

    public void pressA(){        
    	if(validityA[questionIndex]){
    		questionIndex++;
    		resetColors();


    		if(questionIndex >= questionAmount){
    			questionIndex = 0;
    			goToWin();
    		}
    	}else{
	        ButtonA.colors = colRed;
    	}
	}

    public void pressB(){
    	if(validityB[questionIndex]){
			questionIndex++;
			resetColors();


		if(questionIndex >= questionAmount){
			questionIndex = 0;
			goToWin();
		}
    	}else{
	        ButtonB.colors = colRed;
    	}    
	}

	void resetColors(){
		ButtonA.colors = colNormal;
		ButtonB.colors = colNormal;
	}

	void goToWin(){
		winCanvas.SetActive(true);
		gameObject.SetActive(false);
	}

}
