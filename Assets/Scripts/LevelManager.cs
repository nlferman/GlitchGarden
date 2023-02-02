using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

//A script to handle loading levels.

	public float autoLoadNextLevelAfter;
	
	void Start(){
		if (autoLoadNextLevelAfter <= 0) {
			Debug.Log ("Level auto load Disabled.");
		} else{		
		Invoke ("LoadNextLevel", autoLoadNextLevelAfter);
		}
	}

	public void LoadLevel(string name){
		Application.LoadLevel(name);
	}
	public void QuitRequest(){  //Option to quit the game from start menu.
		Application.Quit ();
		Debug.Log ("Quit Request");
	}
	
	public void LoadNextLevel(){
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	void OnTriggerEnter2D (Collider2D collider){
		LoadLevel ("03B Lose");
	}
}
