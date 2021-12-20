using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
    
    public GameObject dialogueBox ;
    public TMP_Text dialogueText;
    public string dialogue;
    public float waitTime = 15f;

    
    // Start is called before the first frame update
    public void StartDialogue(){
        dialogueText.text = dialogue;
        dialogueBox.SetActive(true);
    }

    public IEnumerator StopDialogue(){
        yield return new WaitForSeconds(waitTime);
        dialogueBox.SetActive(false);

    }

    public void setDialogue(string text){
        dialogue = text;
    }
}
