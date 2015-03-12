using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	private GameObject Player; //the player
	private float initialPlayerYPos; //the initial player position
	public List<GameObject> events = new List<GameObject>(); //event array
	private float Score; // score count
	private bool courRunning = false; //to check to see if the courantine method is running

	// so that it doesn't create a extra amount of objects (any logs, clowns, etc.)


	void Start() {
		Player = GameObject.FindGameObjectWithTag ("Player");
		if (Player != null) {
			initialPlayerYPos = Player.transform.position.y;
		}
		//StartCoroutine (generateEvent());
	}
	// Update is called once per frame
	void Update () {	
		if (Input.GetKey(KeyCode.R)) {
			Application.LoadLevel(0);
		}
		if (Player != null) {
			Score += Time.deltaTime;
		}
		if (!courRunning && Player != null) {
			courRunning = true;
			StartCoroutine (generateEvent());
		}
	}

	//Random generator 
	IEnumerator generateEvent() {
		yield return new WaitForSeconds (2f); //executes after every two seconds
		if (Player != null) {
			Instantiate(events[Random.Range(0, events.Count)], new Vector2(Player.transform.position.x + 100f, initialPlayerYPos), Quaternion.identity);
		}
		courRunning = false; //set to false to not invoke this method each frames
	}

	//text for the score
	void OnGUI() {
		string poop = Score.ToString ("#"); //#.0 makes the decimal
		GUI.Label (new Rect (50, 75, 100, 100), "Score: " + poop);
	}
}
