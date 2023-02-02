using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile, gun;
	
	private GameObject projectileParent;
	private Animator animator;
	private AttackerSpawner myLaneSpawner;
	
	// Use this for initialization
	void Start () {
		projectileParent = GameObject.Find ("Projectile");
		
		if (projectileParent == null){
			projectileParent = new GameObject("Projectile");
		}
		
		animator = GameObject.FindObjectOfType<Animator>();
		
		SetMyLaneSpawner();
	}
	
	// Update is called once per frame
	void Update () {
		if (IsAttackerAheadInLane()){
			animator.SetBool ("isAttacking", true);
		} else{
			animator.SetBool ("isAttacking", false);
		}
	}
	
	//Look through all spawners, and set myLaneSpawner if found.
	void SetMyLaneSpawner (){
		AttackerSpawner[] spawnerArray = GameObject.FindObjectsOfType<AttackerSpawner>();
		
		foreach (AttackerSpawner spawner in spawnerArray){
			if (spawner.transform.position.y == transform.position.y){
				myLaneSpawner = spawner;
				return;
			}
		}
		Debug.LogError (name + " Can't find spawner in lane.");
	}
	
	bool IsAttackerAheadInLane (){
		if (myLaneSpawner.transform.childCount <= 0){
			return false;
			}
			
		foreach (Transform attacker in myLaneSpawner.transform){
			if (attacker.transform.position.x > transform.position.x){
					return true;
				}
			}
		
		return false;
	}
	
	private void fire () {
		GameObject newProjecile = Instantiate (projectile) as GameObject;
		newProjecile.transform.parent = projectileParent.transform;
		newProjecile.transform.position = gun.transform.position;
	}
	
	void OnBecameInvisible () {
		Destroy (gameObject);
	}
}
