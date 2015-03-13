using UnityEngine;
using System.Collections;

public class PickUpTest2 : MonoBehaviour {
	
	//Player collision with Pickup Item will destroy all enemy projectiles
	void OnCollisionEnter2D(Collision2D collInfo) {
		if (collInfo.gameObject.CompareTag ("Player")) {
			Time.timeScale = 0.75f;
			collInfo.gameObject.GetComponent<PlayerControllerScript>().timeAffect = 1; //flag time change has occurred
			collInfo.gameObject.GetComponent<PlayerControllerScript>().timeSlowDuration = 1; //time slow duration
			Destroy (this.gameObject);
		}
	}
	


}
