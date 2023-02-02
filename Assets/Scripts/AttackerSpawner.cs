using UnityEngine;
using System.Collections;

public class AttackerSpawner : MonoBehaviour {

	public GameObject[] attackerPrefabArray;
	
	private GameObject parent;

	// Use this for initialization
	void Start () {
		parent = GameObject.Find ("Attackers");
		
		if (parent == null){
			parent = new GameObject("Attackers");
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject thisAttacker in attackerPrefabArray) {
			if (isTimetoSpawn (thisAttacker)) {
				Spawn (thisAttacker);
			}
		}
	
	}
	
	void Spawn(GameObject myGameObject){
		GameObject myAttacker = Instantiate (myGameObject) as GameObject;
		
		myAttacker.transform.parent = transform;
		myAttacker.transform.position = transform.position;
	}
	
	bool isTimetoSpawn (GameObject attackerGameObject){
		Attackers attackers = attackerGameObject.GetComponent<Attackers>();
		
		float meanSpawnDelay = attackers.seenEverySeconds;
		float spawnsPerSecond = 1 / meanSpawnDelay;
		
		if (Time.deltaTime > meanSpawnDelay){
			Debug.LogWarning ("Spawn rate capped by frame rate.");
		}
		
		float threshold = spawnsPerSecond * Time.deltaTime / 5;
		
		return (Random.value < threshold);
	}
}
