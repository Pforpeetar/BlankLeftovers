using UnityEngine;
using System.Collections;

public class PlayerControllerScript : MonoBehaviour
{
//public GameObject refBullet;   //dont think we need anymore
//public GameObject refBullet2; //dont think we need anymore
	public Direction direction = 0; //0 is down, 1 is up, 2 is left, 3 is right
	public Animator animator;
	public float walkVel;
	public float jumpVel;
	private int jumpCount = 0;
	private float hittime;
	private bool isGrounded;
	public Material Default;
	public Material Hit;
// Use this for initialization
	void Start ()
	{
		PlayerInfo.SetState(PState.normal);
			animator = (Animator)GetComponent ("Animator");
	}

// Update is called once per frame
	void Update ()
	{
		SetDirection ();
		if (Time.timeScale!=0) 
		{
			PlayerInfo.changeMana (1);
			CheckInputs ();
			SpriteAnimation ();
		}
		if (hittime + 0.1f < Time.time) {
			GetComponent<SpriteRenderer>().material = Default;
		}
		RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position,new Vector2(0,-1),.15f,9);
		if (hit.collider) {
			animator.SetBool("Jump", false);
			isGrounded = true;
			jumpCount = 0;
		} else {
			animator.SetBool("Jump", true);
			isGrounded = false;
		}
	}

//Checks and sets the animation state for the player
	void SpriteAnimation ()
	{
			setWalk ();
			setIdle ();
	}
	

//Sets the direction for the player
	void SetDirection ()
	{
			if (rigidbody2D.velocity.x <= 0) {
					direction = Direction.left;
			} else if (rigidbody2D.velocity.x > 0) {
					direction = Direction.right;
			}
	}

//Sets the walking animation for the player if they are moving
	void setWalk ()
	{
			if (rigidbody2D.velocity.x != 0) {
				animator.SetBool("Walk", true);
					if (direction == Direction.left) {
						transform.localScale = new Vector3(-1,transform.localScale.y,transform.localScale.z);
					} else if (direction == Direction.right) {
						transform.localScale = new Vector3(1,transform.localScale.y,transform.localScale.z);
					}
			}
	}

//Sets the idle animation for the player if velocities are 0
	void setIdle ()
	{
			if (rigidbody2D.velocity.x == 0) {
			animator.SetBool("Walk", false);
			}
	}


/**
* Used for all player button inputs...I guess...
*/
	void CheckInputs ()
	{
		if(PlayerInfo.GetState().Equals(PState.dead)) {return ;} //dead ppl can't move
		//Consider modifying the same vector everytime instead of creating a new one, performance win?
		if (PlayerInfo.GetState().Equals(PState.normal)) {
			rigidbody2D.velocity = new Vector2 (Input.GetAxis ("Horizontal") * walkVel, gameObject.rigidbody2D.velocity.y);
			if (Input.GetButtonDown ("Jump")) {
				if (jumpCount < 1) {
				rigidbody2D.velocity = new Vector2(gameObject.rigidbody2D.velocity.x, jumpVel);
				jumpCount++;
				Debug.Log("Jump Count: " + jumpCount);
				}
			}
		}
	}

	void stopAttackAnim ()
	{
		animator.SetBool ("Attack", false);
	}
	
}
