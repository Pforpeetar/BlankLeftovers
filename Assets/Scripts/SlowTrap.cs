using UnityEngine;
using System.Collections;

public class SlowTrap : MonoBehaviour {
	private float tempVel;
	private PlayerControllerScript p;
	void OnCollisionEnter2D(Collision2D collInfo) {
		if (collInfo.gameObject.CompareTag ("Player")) {
			SlowPlayer(collInfo);
		}
	}
	
	//Destroy all Enemy Projectiles
	void SlowPlayer(Collision2D collInfo)
	{
		p = collInfo.gameObject.GetComponent<PlayerControllerScript> ();
		tempVel = p.highestWalkVel;
		p.walkVel /= 2f;
	}

	void OnCollisionExit2D(Collision2D collInfo) {
		if (collInfo.gameObject.CompareTag ("Player")) {
			p.walkVel = tempVel;
		}
	}
}
