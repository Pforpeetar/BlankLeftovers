using UnityEngine;
using System.Collections;

public class FloorMove : MonoBehaviour {
	public GameObject target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector2 (target.transform.position.x, -7.5f);
	}
}
