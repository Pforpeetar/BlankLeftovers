using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{
	public Texture bgImage;
	public bool showYesNoPrompt = false;
	public float guiPlacementY;
	// Use this for initialization
	void Start ()
	{
	}
	
	void OnGUI ()
	{
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), bgImage);
		
		if (GUI.Button (new Rect (Screen.width * .5f, Screen.height * .4f, Screen.width * .3f, Screen.height * .1f), "New Game")) {
			//print ("Clicked Play Game");
			Application.LoadLevel (Application.loadedLevel + 1); //theoretically this should be the first level
		}
		//(new Rect (Screen.width * .5f, Screen.height * .55f, Screen.width * .5f, Screen.height * .1f)
		if (GUILayout.Button ("End Game")) {
			//print ("Clicked End Game");
			Debug.Log ("poop");
			showYesNoPrompt = true;
		}
	
	}
}
