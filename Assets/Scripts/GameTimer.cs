using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {

	private Slider slider;
	private AudioSource audioSource;
	private LevelManager levelManager;
	private GameObject winText;
	
	private bool isEndOfLevel = false;
	
	public float levelTime = 100f;
	
	// Use this for initialization
	void Start () {
		slider = GetComponent<Slider>();
		audioSource = GetComponent<AudioSource>();
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		FindWinText ();
	}

	void FindWinText ()
	{
		winText = GameObject.Find("Win Text");
		if (!winText) {
			Debug.LogWarning ("Please create a Win Text UI Element.");
		}
		winText.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		slider.value = (Time.timeSinceLevelLoad / levelTime);
		
		if (Time.timeSinceLevelLoad >= levelTime && !isEndOfLevel){
			handleWinCondition ();
		}
	
	}

	void handleWinCondition ()
	{
		DestroyAllTaggedObjects();
		audioSource.Play ();
		winText.SetActive (true);
		Invoke ("LoadNextLevel", audioSource.clip.length);
		isEndOfLevel = true;
	}
	//Destroys all objects with tag: destroyOnWin.
	void DestroyAllTaggedObjects(){
		GameObject[] taggedObjectArray = GameObject.FindGameObjectsWithTag("destroyOnWin");
		
		foreach (GameObject taggedObject in taggedObjectArray){
			Destroy(taggedObject);
			}
		}
	
	void LoadNextLevel(){
		levelManager.LoadNextLevel();
	}
}
