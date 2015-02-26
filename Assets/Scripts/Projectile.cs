using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public float projectileDuration = 3;
	public string Target;

	// Use this for initialization
	void Start () {
		Destroy(gameObject, projectileDuration);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D collInfo) {
		if (collInfo.gameObject.CompareTag (Target)) {
			Destroy(collInfo.gameObject);
		}
	}
}
