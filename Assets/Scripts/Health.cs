using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float health;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void DealDamage (float damage){
		health -= damage;
		if (health <= 0){
			DestroyObject ();
		}
	}
	
	public void DestroyObject(){
		Destroy (gameObject);
	}
}
