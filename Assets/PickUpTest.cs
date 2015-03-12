using UnityEngine;
using System.Collections;

public class PickUpTest : MonoBehaviour {
	void Start() {

	}

	void Update() {
		//rigidbody2D.velocity = new Vector2 (-10f, 0f);
	}

	//Player collision with Pickup Item will destroy all enemy projectiles
	void OnCollisionEnter2D(Collision2D collInfo) {
		if (collInfo.gameObject.CompareTag ("Player")) {
			DestroyEnemies();
			Destroy (this.gameObject);
		}
	}

	//Destroy all Enemy Projectiles
	void DestroyEnemies()
	{
		GameObject[] enemyProjectiles = GameObject.FindGameObjectsWithTag("Enemy");

		for (int i = 0; i< enemyProjectiles.Length; i++) {
			Destroy (enemyProjectiles[i]);
		}
	}

}
