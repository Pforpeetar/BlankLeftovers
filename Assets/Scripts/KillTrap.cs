using UnityEngine;
using System.Collections;

public class KillTrap : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collInfo) {
		if (collInfo.gameObject.CompareTag ("Player")) {
			Destroy (collInfo.gameObject);
		}
	}
}
