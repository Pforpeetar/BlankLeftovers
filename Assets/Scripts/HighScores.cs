using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Collections.Generic;

/*
 * @author Omari Straker
 * */

public class Score{
	public int rank;
	public string name;
	public int score;
	
	public Score (int r, string n, int sco)
	{
		rank = r;
		name = n;
		score = sco;
	}
}

public class HighScores : MonoBehaviour {

	private const int numOfHighScores = 13;
	public static string HighScoreFilePath = Application.persistentDataPath + "/HighScores.hanabi";
	public static Score[] ListOfHighScores;
	
	// Use this for initialization
	void Start () {
		if (!File.Exists(HighScoreFilePath)) { //check to see if there is a high score file already
			CreateHighScoreDefaultSet(); //create file if it doesn't exist
			SaveHighScoresToFile();
		}
		else
		{
			LoadHighScoresFromFile();	
		}	
	}

	public static void LoadHighScoresFromFile()
	{	
		try
		{
			StreamReader currFile = new StreamReader(HighScoreFilePath);
			ListOfHighScores = new Score[numOfHighScores]; 
			int index = 0;
			string linePlease = "";
			linePlease = currFile.ReadLine();
			while (index < 13)
			{
				string[] currStageSplit = linePlease.Split('|');
				ListOfHighScores[index] = new Score(Int32.Parse(currStageSplit[0]),currStageSplit[1],Int32.Parse(currStageSplit[2]));
				index++;
			}
			currFile.Close();
		}
		catch (Exception e)
		{
			//if there is an exception we should probably at least use the base set of high scores
			Debug.Log(e.Message);
			CreateHighScoreDefaultSet();
			SaveHighScoresToFile();
		}
	}

	public static void SaveHighScoresToFile()
	{
		try 
		{
			if (File.Exists(HighScoreFilePath))
			{
				File.Delete(HighScoreFilePath); //idk how to overwrite a file that already exists sorry
			}
			StreamWriter currFile = new StreamWriter(HighScoreFilePath);
			foreach (Score sc in ListOfHighScores)
			{
					currFile.WriteLine("" + sc.rank + "|" + sc.name + "|" + sc.score);
			}
			currFile.Close();
		}
		catch (Exception e)
		{
			Debug.Log(e.Message);
		}
	}
	
	public static void CreateHighScoreDefaultSet()
	{
		ListOfHighScores = new Score[numOfHighScores];
		ListOfHighScores[0] = new Score (1,"Hanabi",13);
		ListOfHighScores[1] = new Score (2,"Pham",12);
		ListOfHighScores[2] = new Score (3,"Monta",11);
		ListOfHighScores[3] = new Score (4,"Panda",10);
		ListOfHighScores[4] = new Score (5,"Express",9);
		ListOfHighScores[5] = new Score (6,"Samantha",8);
		ListOfHighScores[6] = new Score (7,"Chad",7);
		ListOfHighScores[7] = new Score (8,"Ichigo",6);
		ListOfHighScores[8] = new Score (9,"Renji",5);
		ListOfHighScores[9] = new Score (10,"Rukia",4);
		ListOfHighScores[10] = new Score (11,"Ishida",3);
		ListOfHighScores[11] = new Score (12,"Orihime",2);
		ListOfHighScores[12] = new Score (13,"Wazero",1);
	}
}