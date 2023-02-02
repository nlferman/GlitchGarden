using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Attackers))]
public class Lizard : MonoBehaviour {

	private Animator anim;
	private Attackers attackers;
	
	// Use this for initialization
	void Start () {
		attackers = gameObject.GetComponent<Attackers>();
		anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D (Collider2D collider){
		GameObject obj = collider.gameObject;
		
		//Leave method if not colliding with a defender.
		if (!obj.GetComponent<Defenders>()){
			return;
		} 
		
		else {
			anim.SetBool ("isAttacking", true);
			attackers.attack (obj);
		}
	}
}
