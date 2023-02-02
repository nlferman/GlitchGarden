using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody2D))]
public class Attackers : MonoBehaviour {
		
		[Tooltip ("Average number of seconds between appearances.")]
		public float  seenEverySeconds;
		[Range (-3f, 3f)] private float currentSpeed;
		private GameObject currentTarget;
		private Animator animator;
		

	// Use this for initialization
	void Start () {
		Rigidbody2D myRigidBody = gameObject.AddComponent<Rigidbody2D>();
		myRigidBody.isKinematic = true;
		animator = gameObject.GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * currentSpeed * Time.deltaTime);
			
		if (!currentTarget){
			animator.SetBool("isAttacking", false);
		}
		
		
		
	}
	
	
	void OnTriggerEnter2D (){
		//Debug.Log ("Collision Detected for: " + name);
	}
	
	public void setSpeed (float speed){
		currentSpeed = speed;
	}
	
	//Called from animator at time of actual blow (within the attacking animation).
	public void strikeCurrentTarget(float damage){
		if (currentTarget){
			Health health = currentTarget.GetComponent<Health>();
			if (health){
				health.DealDamage(damage);
				}
			}
		}
	
	//Tells the animator to begin the attacking animation.
	public void attack (GameObject obj){
		currentTarget = obj;
	}
}
