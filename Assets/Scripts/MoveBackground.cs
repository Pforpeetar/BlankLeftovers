using UnityEngine;
using System.Collections;

public class MoveBackground : MonoBehaviour {
	public Vector3 screenPosition = new Vector3(0,0,20);
	public Camera camera;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collInfo) {
		//Vector3 center = camera.renderer.bounds.center;
		float height = camera.orthographicSize * 2f;
		float width = height / (float)Screen.height * (float)Screen.width;
		if (collInfo.CompareTag("Camera")) {
//			Debug.Log("Colliding");
			//transform.position = camera.ScreenToWorldPoint(screenPosition);
			transform.position = new Vector3(transform.position.x + width * 4, transform.position.y, transform.position.z);
		}
	}
}
