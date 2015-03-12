using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	private GameObject Player; //the player
	private float initialPlayerYPos; //the initial player position
	public List<GameObject> events = new List<GameObject>(); //event array
	public static float score; // score count
	private bool courRunning = false; //to check to see if the courantine method is running
	// so that it doesn't create a extra amount of objects (any logs, clowns, etc.)
	public static string stringToEdit = "Enter name";
	public static bool userDead = false;

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
			score += Time.deltaTime;
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
		string currentScore = score.ToString ("#"); //#.0 makes the decimal
		GUI.Label (new Rect (50, 75, 100, 100), "Score: " + currentScore);

		if (userDead) {
			for (int i = 0; i <= 12; i++) {
				GUI.Box(new Rect(Screen.width/3, Screen.height/15 + Screen.height/15 + Screen.height/15*i, Screen.width/4, Screen.height/20), HighScores.ListOfHighScores[i].name + " HighScore " + (i+1) + ": " + HighScores.ListOfHighScores[i].score);
			}
			//GUI.Box(new Rect(Screen.width/2, Screen.height/2, 200, 20), "HighScore1: " + HighScores.ListOfHighScores[0].score);
			stringToEdit = GUI.TextField(new Rect(Screen.width/3, Screen.height/20, Screen.width/4, Screen.height/20), stringToEdit, 25);

			if (GUI.Button(new Rect(Screen.width/3, 0, Screen.width/4, Screen.height/20), "Click to save")){
				updateScores();
			}
		}
	}

	public static void updateScores() {
		Score newHighScore = new Score(0, stringToEdit, (int) score);
		//Debug.Log (newHighScore);
		bool duplicate = false;
		for (int i = 0; i < 13; i++) {
			if (newHighScore.name.Equals(HighScores.ListOfHighScores[i].name)) {
				duplicate = true;
			}
		}

		for (int i = 12; i >= 0; i--) {
			if (!duplicate) {
				if (newHighScore.score > HighScores.ListOfHighScores[i].score) {
					if (i < 12) {
						newHighScore.rank = HighScores.ListOfHighScores[i].rank;
						HighScores.ListOfHighScores[i].rank++;
						Score temp = HighScores.ListOfHighScores[i];
						HighScores.ListOfHighScores[i] = newHighScore;
						HighScores.ListOfHighScores[i+1] = temp;
					} else if (i == 12) {
						newHighScore.rank = HighScores.ListOfHighScores[i].rank;
						HighScores.ListOfHighScores[i] = newHighScore;
					}
				}
			}
		}

		HighScores.SaveHighScoresToFile ();
	}
}
