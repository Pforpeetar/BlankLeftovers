using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	private GameObject Player;
	private float initialPlayerYPos;
	public List<GameObject> events = new List<GameObject>();
	private float Score;
	private bool courRunning = false;

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

	IEnumerator generateEvent() {
		yield return new WaitForSeconds (2f);
		if (Player != null) {
			Instantiate(events[Random.Range(0, events.Count)], new Vector2(Player.transform.position.x + 100f, initialPlayerYPos), Quaternion.identity);
		}
		courRunning = false;
	}

	void OnGUI() {
		string poop = Score.ToString ("#");
		GUI.Label (new Rect (50, 75, 100, 100), "Score: " + poop);
	}
}
