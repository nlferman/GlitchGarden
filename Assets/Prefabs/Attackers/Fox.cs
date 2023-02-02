using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Attackers))]
public class Fox : MonoBehaviour {
	
	private Attackers attackers;
	private Animator anim;
	
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
		
		if (obj.GetComponent<Stone>()){
			anim.SetTrigger ("isBlocked");
		} else {
			anim.SetBool ("isAttacking", true);
			attackers.attack (obj);
		}
	}
}