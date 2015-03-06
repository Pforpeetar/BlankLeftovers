using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public float projectileDuration = 3;
	public string Target;
	// Use this for initialization
	void Start () {
		Destroy(gameObject, projectileDuration);
	}

	void OnCollisionEnter2D(Collision2D collInfo) {
		if (collInfo.gameObject.CompareTag (Target)) {
			Destroy(collInfo.gameObject);
		}
		if (collInfo.gameObject.CompareTag ("Projectile")) {
			PlayerControllerScript.overlap = true;
		}
	}
}
