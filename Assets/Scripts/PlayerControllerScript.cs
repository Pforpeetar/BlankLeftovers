using UnityEngine;
using System.Collections;

public class PlayerControllerScript : MonoBehaviour
{
	public LayerMask mask; //ray cast
	public LayerMask mask2; //ray cast
	public Direction direction; //0 is down, 1 is up, 2 is left, 3 is right
	public Animator animator; //Animation
	public float walkVel = 20; //velocity of the characters start
	public float jumpVel; //characters jump velocity
	private int jumpCount = 0; 
	private bool isGrounded; //character is on the ground
	public Camera mainCamera; //get main camera
	public float maxMana = 100; //fixed  max mana
	private float mana = 100; //fixed current mana
	public static bool overlap = false; //

	public GameObject pRangePrefab; //Projectile prefab

// Use this for initialization
	void Start ()
	{
		PlayerInfo.SetState(PState.normal);
		animator = (Animator)GetComponent ("Animator");
	}

	void setOverlap(bool boo) {
		overlap = boo;
	}

// Update is called once per frame
	void FixedUpdate ()
	{
		mana += Time.deltaTime * 20f;
		walkVel += Time.deltaTime / 3;
		if (mana > maxMana) {
			mana = maxMana;
		}
		if (mana < 0) {
			mana = 0;
		}
		SetDirection ();
		if (Time.timeScale!=0) 
		{
			CheckInputs ();
			//SpriteAnimation ();
		}
		RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position,new Vector2(0,-1),5f,mask);
		RaycastHit2D hit2 = Physics2D.Raycast(gameObject.transform.position,new Vector2(0,-1),5f,mask2);
//		Debug.Log (hit.collider);
		//Debug.DrawRay(gameObject.transform.position, new Vector2(0,-1));
		if (hit.collider || hit2.collider) {
			animator.SetBool("Jump", false);
			isGrounded = true;
			jumpCount = 0;
		} else {
			animator.SetBool("Jump", true);
			isGrounded = false;
		}
	}

	void OnGUI() {
		string poop = mana.ToString("#");
		string poop2 = walkVel.ToString("#");
		GUI.Label (new Rect (50, 25, 100, 100), "Mana: " + poop);
		GUI.Label (new Rect (50, 40, 100, 100), "WalkSpeed: " + poop2);
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
	
	void CheckInputs ()
	{
		if(PlayerInfo.GetState().Equals(PState.dead)) {return ;} //dead ppl can't move
		//Consider modifying the same vector everytime instead of creating a new one, performance win?
		if (PlayerInfo.GetState().Equals(PState.normal)) {
			//rigidbody2D.velocity = new Vector2 (Input.GetAxis ("Horizontal") * walkVel, gameObject.rigidbody2D.velocity.y);
			rigidbody2D.velocity = new Vector2 (walkVel, gameObject.rigidbody2D.velocity.y);
			if (Input.GetButtonDown ("Jump")) {
				if (jumpCount < 1) {
				rigidbody2D.velocity = new Vector2(gameObject.rigidbody2D.velocity.x, jumpVel);
				jumpCount++;
				}
			}
			if (Input.GetButton("Fire1") && mana >= 2) {
				RangeInput();
			}
		}
	}

	void RangeInput() {
		if (pRangePrefab != null && !overlap) { //checks if entity has a range projectile
			mana -= 2;
			Vector3 pos = Input.mousePosition;
			pos.z = 2;
			pos = mainCamera.ScreenToWorldPoint(pos);
			GameObject.Instantiate (pRangePrefab, pos, Quaternion.identity);
		}
		overlap = false;
	}
}
