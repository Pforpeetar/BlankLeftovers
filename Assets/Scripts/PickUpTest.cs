using UnityEngine;
using System.Collections;

public class PickUpTest : MonoBehaviour {

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
		GameObject[] enemyProjectiles = GameObject.FindGameObjectsWithTag("EnemyProjectile");

		for (int i = 0; i< enemyProjectiles.Length; i++) {
			Destroy (enemyProjectiles[i]);
		}
	}

}
