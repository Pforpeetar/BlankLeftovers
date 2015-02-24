using UnityEngine;
using System.Collections;

public class PlayerControllerScript : MonoBehaviour
{
	public Direction direction; //0 is down, 1 is up, 2 is left, 3 is right
	public Animator animator;
	public float walkVel2;
	public float jumpVel;
	private int jumpCount = 0;
	private float hittime;
	private bool isGrounded;
	public Material Default;
	public Material Hit;
	public Camera mainCamera;

	public GameObject pRangePrefab; //Projectile prefab
	private GameObject instanceOfRangePrefab; //used to create an instance of the prefab in order to send message to the script. 
// Use this for initialization
	void Start ()
	{
		PlayerInfo.SetState(PState.normal);
		//	animator = (Animator)GetComponent ("Animator");
	}

// Update is called once per frame
	void Update ()
	{
		SetDirection ();
		if (Time.timeScale!=0) 
		{
			CheckInputs ();
			//SpriteAnimation ();
		}
		if (hittime + 0.1f < Time.time) {
			GetComponent<SpriteRenderer>().material = Default;
		}
		RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position,new Vector2(0,-1),5f,9);
//		Debug.Log (hit.collider);
		//Debug.DrawRay(gameObject.transform.position, new Vector2(0,-1));
		if (hit.collider) {
			//animator.SetBool("Jump", false);
			isGrounded = true;
			jumpCount = 0;
		} else {
			//animator.SetBool("Jump", true);
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
			if (rigidbody2D.velocity.x < 0) {
					direction = Direction.left;
			} else if (rigidbody2D.velocity.x > 0) {
					direction = Direction.right;
			}
	}

//Sets the walking animation for the player if they are moving
	void setWalk ()
	{
			if (rigidbody2D.velocity.x != 0) {
				//animator.SetBool("Walk", true);
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
			//animator.SetBool("Walk", false);
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
			//rigidbody2D.velocity = new Vector2 (Input.GetAxis ("Horizontal") * walkVel, gameObject.rigidbody2D.velocity.y);
			//Debug.Log("WHAT IS HAPPENING!?");
			rigidbody2D.velocity = new Vector2 (walkVel2, gameObject.rigidbody2D.velocity.y);
			if (Input.GetButtonDown ("Jump")) {
				if (jumpCount < 1) {
				rigidbody2D.velocity = new Vector2(gameObject.rigidbody2D.velocity.x, jumpVel);
				jumpCount++;
				//Debug.Log("Jump Count: " + jumpCount);
				}
			}
			if (Input.GetButton("Fire1")) {
				RangeInput();
			}
		}
	}

	void RangeInput() {
		if (pRangePrefab != null) { //checks if entity has a range projectile
			Vector3 pos = Input.mousePosition;
			pos.z = 2;
			pos = mainCamera.ScreenToWorldPoint(pos);
			instanceOfRangePrefab = (GameObject)GameObject.Instantiate (pRangePrefab, pos, Quaternion.identity);

			//instanceOfRangePrefab = (GameObject)GameObject.Instantiate (pRangePrefab, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
//			Debug.Log("poop");
		}
		//instanceOfRangePrefab.SendMessage ("setDirection", direction); //too lazy to make struct, send player direction to prefab
		//instanceOfRangePrefab.SendMessage ("execute", gameObject); //sends gameobject of entity so projectile knows where to spawn from*/
	}

	void stopAttackAnim ()
	{
		//animator.SetBool ("Attack", false);
	}
	
}
