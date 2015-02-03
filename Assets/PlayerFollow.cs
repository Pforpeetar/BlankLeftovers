﻿using UnityEngine;
using System.Collections;

public class PlayerFollow : MonoBehaviour {
	public GameObject target;
	private float xPos;
	private float yPos;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		xPos = target.transform.position.x;
		yPos = target.transform.position.y;
		transform.position = new Vector3 (xPos, yPos, transform.position.z);
	}
}
