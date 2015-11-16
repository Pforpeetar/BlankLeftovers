using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour {
	public float speed;
	private GameObject player;                      // Reference to the player.
	private Vector3 playerTransform;                      // Reference to the player's transform.
	
	void Start() {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	void FixedUpdate () {
		speed += Time.deltaTime/2;
		if (player != null) {
			playerTransform = player.transform.position;
			Chasing ();
		} else {
			GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
		}
	}

	void Chasing ()
	{
		Vector2 Playerdirection;
		float Xdif;
		float Ydif;
		Xdif = playerTransform.x - transform.position.x;
		Ydif = playerTransform.y - transform.position.y;
		
		Playerdirection = new Vector2 (Xdif, Ydif);
		GetComponent<Rigidbody2D>().velocity = (Playerdirection.normalized * speed);
	}
}
