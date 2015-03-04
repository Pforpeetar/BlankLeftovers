using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour {
	public GameObject target;
	
	// Update is called once per frame
	void Update () {
		rigidbody2D.velocity = new Vector2 (25f, 0);
	}
}
