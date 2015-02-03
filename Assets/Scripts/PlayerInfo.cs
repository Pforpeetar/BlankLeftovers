using UnityEngine;
using System.Collections;
/*
 * Static class used to represent player metadata
 * Made static because it makes my life easier
 * Since no instance of this class will ever be created, all added variables/methods should be static
 */
public static class PlayerInfo
{
	private const int MAXMANA = 300; //max MP that player can have
	private const int MAXHEALTH = 100; //max HP that player can have
	private static int mana = MAXMANA; //initialize player mana
	private static int health = MAXHEALTH; //initialize player health
	private static PState playerState = PState.inmenus; 


	//umm....get the player's current health
	public static int getHealth()
	{
		return health; 
	}

	public static int getMaxHealth() {
		return MAXHEALTH;
	}

	//set player's health to a specific value like if the level was restarted
	public static void setHealth(int setToWhat)
	{
		health = setToWhat;
		if (health > MAXHEALTH)
		{
			health = MAXHEALTH;
		}
	}

	//get player's current MP
	public static int getMana()
	{
		return mana;
	}

	public static int getMaxMana() {
		return MAXMANA;
	}

	//set player's MP to a specific value like if the level was restarted
	public static void setMana(int setToWhat){
		mana += setToWhat;
		if (mana > MAXMANA)
		{
			mana = MAXMANA;
		}
	}

	//used maybe after player dies or a full restore pickup is dropped to reset the players stuff
	public static void resetPlayer()
	{
		mana = MAXMANA;
		health = MAXHEALTH;
	}

	/*used to increase or decreased player's health. 
	  positive number for increase
	  negative number for decrease */
	public static void changeHealth(int byHowMuchHealth)
	{
		health += byHowMuchHealth;
		if (health > MAXHEALTH)
		{
			health = MAXHEALTH;
		}
		if (health <= 0)
		{
			health = 0;
			//Application.LoadLevel(Application.loadedLevel);
			//TODO: play death animation
			SetState(PState.dead);
		}
	}
	/*used to increase or decreased player's mana. 
	  positive number for increase
	  negative number for decrease */
	public static void changeMana(int byHowMuchMana)
	{
		mana += byHowMuchMana;
		if (mana > MAXMANA)
		{
			mana = MAXMANA;
		}
		if (mana < 0)
		{
			mana = 0;
		}
	}

	public static PState GetState()
	{
		return playerState;
	}

	public static void SetState(PState stateToSet)
	{
		playerState = stateToSet;
	}
}	