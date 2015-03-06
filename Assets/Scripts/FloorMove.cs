using UnityEngine;
using System.Collections;

public class FloorMove : MonoBehaviour {
	public GameObject target;

	// Update is called once per frame
	void Update () {
		if (target != null) {
			transform.position = new Vector2 (target.transform.position.x, -7.5f);
		}
	}
}
