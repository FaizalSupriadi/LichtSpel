using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// This class will handle the switching between menu and the game.
public class SceneSwitcher : MonoBehaviour
{
	public static void next(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public static void back(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}

	public static void goTo(int scene){
		SceneManager.LoadScene(scene);
	}

	public static void quit(){
		Debug.Log("QUIT");
		Application.Quit();
	}

	// public void buttonSound(){
	// 	// FindObjectOfType<AudioManager>().Play("Button1");
	// }
}
