using UnityEngine;
using System.Collections;

public class MoveBackground : MonoBehaviour {
	public Vector3 screenPosition = new Vector3(0,0,20);
	public Camera camera;
	public float distance = 1f;

	void OnTriggerEnter2D(Collider2D collInfo) {
		//Vector3 center = camera.renderer.bounds.center;
		float height = camera.orthographicSize * 2f;
		float newHeight = gameObject.renderer.bounds.size.y;
		float width = height / (float)Screen.height * (float)Screen.width;
		float newWidth = gameObject.renderer.bounds.size.x;
		if (collInfo.CompareTag("Camera")) {
//			Debug.Log("Colliding");
			//transform.position = camera.ScreenToWorldPoint(screenPosition);
			transform.position = new Vector3(transform.position.x + newWidth * distance, transform.position.y, transform.position.z);
		}
	}
}
