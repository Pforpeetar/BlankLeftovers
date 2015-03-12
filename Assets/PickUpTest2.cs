using UnityEngine;
using System.Collections;

public class PickUpTest2 : MonoBehaviour {

	private float currentTime = 0; //store time of when TimeScale is off
	void Start() {
		
	}
	
	void Update() {


	}
	
	//Player collision with Pickup Item will destroy all enemy projectiles
	void OnCollisionEnter2D(Collision2D collInfo) {
		if (collInfo.gameObject.CompareTag ("Player")) {
			Time.timeScale = 0.5f;
			collInfo.gameObject.GetComponent<PlayerControllerScript>().timeAffect = 1; //flag time change has occurred
			collInfo.gameObject.GetComponent<PlayerControllerScript>().timeSlowDuration = 3; //time slow duration
			Destroy (this.gameObject);
		}
	}
	


}
