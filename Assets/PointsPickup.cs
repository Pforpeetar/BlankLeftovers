using UnityEngine;
using System.Collections;

public class PointsPickup : MonoBehaviour {

	//Player collision with Pickup Item will destroy all enemy projectiles
	void OnCollisionEnter2D(Collision2D collInfo) {
		if (collInfo.gameObject.CompareTag ("Player")) {
			GameManager.score += 3;
			Destroy(gameObject);
		}
	}
}
