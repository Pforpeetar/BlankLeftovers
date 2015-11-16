using UnityEngine;
using System.Collections;

public abstract class BulletDesu : MonoBehaviour {
	protected Animator animator;
	public float animationDuration;
	public int damageValue; //how much damage they do
	public string TargetType; //Set to Player or Enemy in Inspector
	public int knockBackVelocity; //for knockback
	public float projectileDuration;
	public float hitDelay; //for a delay between when another hit would register 
	public bool destroyOnCollision;
	//public AudioClip bulletSound;
	// Use this for initialization

	void Start () {
		SuperStart ();
	}

	protected void SuperStart() {
		animator = (Animator)GetComponent ("Animator");
		if (TargetType == null) {TargetType = "Entity";}
		Destroy (gameObject,projectileDuration);
	}

	public abstract void execute (GameObject g);
	public abstract void setDirection (Direction d);

	protected void OnCollisionEnter2D(Collision2D collInfo) {
		//Debug.Log(collInfo.gameObject.name);		
		//if (animator) {
		//	animator.SetBool ("Does Collide", true);} //not all objects that this script is attached to have animations
		if (collInfo.gameObject.CompareTag(TargetType))
		{
			DamageStruct thisisntastructanymore = new DamageStruct(damageValue,GetComponent<Collider2D>().gameObject,knockBackVelocity,hitDelay);
			//struct used to pass more than one parameter through send message, which only lets you pass one object as a parameter
			collInfo.gameObject.SendMessage("callDamage",thisisntastructanymore);
		}
		if (destroyOnCollision == true) {
			gameObject.GetComponent<Collider2D>().enabled = false; //once it hits one object it should no longer be able to hit another object
			GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
			Destroy(gameObject, animationDuration);
		}
		Destroy(gameObject, projectileDuration);
	}
}
