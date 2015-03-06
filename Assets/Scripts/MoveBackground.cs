using UnityEngine;
using System.Collections;

public class MoveBackground : MonoBehaviour {
	public Vector3 screenPosition = new Vector3(0,0,20);
	public Camera camera;
	public int distance = 4;

	void OnTriggerEnter2D(Collider2D collInfo) {
		//Vector3 center = camera.renderer.bounds.center;
		float height = camera.orthographicSize * 2f;
		float width = height / (float)Screen.height * (float)Screen.width;
		if (collInfo.CompareTag("Camera")) {
//			Debug.Log("Colliding");
			//transform.position = camera.ScreenToWorldPoint(screenPosition);
			transform.position = new Vector3(transform.position.x + width * distance, transform.position.y, transform.position.z);
		}
	}
}
