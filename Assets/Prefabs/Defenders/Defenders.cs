using UnityEngine;
using System.Collections;

public class Defenders : MonoBehaviour {

	public int starCost = 100;

	private StarDisplay starDisplay;

	// Use this for initialization
	void Start () {
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void addStars (int amount) {
		starDisplay.addStars (amount);
	}
	
}
