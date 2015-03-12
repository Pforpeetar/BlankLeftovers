using UnityEngine;
using System.Collections;

public class DestroyObject : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D collInfo) {
		if (collInfo.CompareTag("Camera")) {
			Destroy (gameObject);
		}
	}
}
