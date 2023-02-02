using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Buttons : MonoBehaviour {

	public GameObject defenderPrefab;
	public static GameObject selectedDefender;
	
	private Buttons[] buttonArray;
	private Text costText;

	// Use this for initialization
	void Start () {
	
		buttonArray = GameObject.FindObjectsOfType<Buttons>();
		costText = GetComponentInChildren<Text>();
		if (!costText) {Debug.LogWarning (name + " has no star cost.");}
		costText.text = defenderPrefab.GetComponent<Defenders>().starCost.ToString();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown (){
	
		foreach (Buttons thisButton in buttonArray){
			thisButton.GetComponent<SpriteRenderer>().color = Color.black;
		}
		GetComponent<SpriteRenderer>().color = Color.white;
		
		selectedDefender = defenderPrefab;
		print (selectedDefender);
	}
}
