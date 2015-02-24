using UnityEngine;
using System.Collections;

public class FloorMove : MonoBehaviour {
	public GameObject target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody2D.velocity = new Vector3 (target.rigidbody2D.velocity.x, rigidbody2D.velocity.y);
	}
}
