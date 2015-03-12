using UnityEngine;
using System.Collections;

public class PickUpTest : MonoBehaviour {
	void Start() {

	}

	void Update() {
		//rigidbody2D.velocity = new Vector2 (-10f, 0f);
	}

	void OnCollisionEnter2D(Collision2D collInfo) {
		if (collInfo.gameObject.CompareTag ("Player")) {
			DestroyProjectiles();
			Destroy (this.gameObject);
		}
	}

	void DestroyProjectiles()
	{
		GameObject[] projectiles = GameObject.FindGameObjectsWithTag("Projectile");

		for (int i = 0; i< projectiles.Length; i++) {
			Destroy (projectiles[i]);
		}
	}

}
