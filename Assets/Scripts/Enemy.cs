using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public GameObject Player;
	public GameObject projectile;
	Vector2 dir;
	private float currTime;
	public float cooldown = 5;
	// Use this for initialization
	void Start () {
		PlayerControllerScript p;
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody2D.velocity = new Vector2(-10, rigidbody2D.velocity.y);

		if (currTime <= Time.time) {
			currTime = Time.time + cooldown;
			dir = new Vector2(-20f, Player.transform.position.y - transform.position.y);
			GameObject projectileClones = cloneObject(projectile, transform.position, dir, Quaternion.identity);
			//GameObject projectileClones = (GameObject)GameObject.Instantiate(projectile, transform.position, Quaternion.identity);
			//projectileClones.rigidbody2D.velocity = new Vector2(-10f, 0);
		}
	}

	void OnCollisionEnter2D(Collision2D collInfo) {
		if (collInfo.gameObject.CompareTag ("Player")) {
			Destroy(collInfo.gameObject);
		}
	}

	public static GameObject cloneObject (GameObject bulletToClone, Vector3 placetoCreate, Vector3 velocity, Quaternion orientation)
	{		
		GameObject clonedesu = (GameObject)ScriptableObject.Instantiate (bulletToClone, placetoCreate, orientation);
		//Debug.Log("poops: " + clonedesu);
		if (clonedesu.rigidbody2D) {
			clonedesu.rigidbody2D.velocity = velocity;
			//Debug.Log ("poop da doops");
		}
		if(clonedesu.audio)
		{
			clonedesu.audio.Play();
		}
		return clonedesu;
	}
}
